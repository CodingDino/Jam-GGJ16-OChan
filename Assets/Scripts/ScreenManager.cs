using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
	TITLE,
	//--
	ORDER,
	KETTLE,
	TEA,
	BREW,
	CUP,
	SUGAR,
	DRINK,
	//--
	RESULT
}

public class ScreenManager : Singleton<ScreenManager> {

	public GameState m_currentState = GameState.TITLE;
	public GameState m_viewingState = GameState.TITLE;
	public int customersPerDay = 5;

	private int customersServed = 0;

	public float m_transitionSpeed = 10;
	public Camera m_camera;
	public List<Transform> screenPositions = new List<Transform>();
	public List<Color> screenColours = new List<Color>();
	public MonoBehaviour[] subScreens;
	private Transform oldScreen = null;
	private Vector3 oldScreenTarget;

	bool animating = false;

	public static GameState GetFocusState() { return instance.m_currentState; }
	public static GameState GetViewingState() { return instance.m_viewingState; }

	public void ArrowButtonPressed()
	{
		if (animating)
			return;

		GameState newState = m_currentState + 1;

		if (m_currentState == m_viewingState)
		{
			if (m_currentState == GameState.DRINK)
			{
				++customersServed;

				if (customersServed < customersPerDay)
				{
					newState = GameState.ORDER;
				}
			}
			else if (m_currentState == GameState.RESULT)
			{
				customersServed = 0;
				newState = GameState.ORDER;
			}
			ChangeFocusState(newState);
		}
		else
		{
			ChangeViewingState(m_currentState);
		}
	}

	public void CustomerButtonPressed()
	{
		ChangeViewingState(GameState.ORDER, false);
	}

	public void ChangeFocusState(GameState _newState)
	{
		((SubScreen)subScreens[(int)m_currentState]).ScreenFocusLost();
		((SubScreen)subScreens[(int)_newState]).ScreenFocusGained();

		m_currentState = _newState;
		ChangeViewingState(m_currentState);
	}

	public void ChangeViewingState(GameState _newState, bool _fromRight = true)
	{
		if (_newState == m_viewingState)
			return;

		((SubScreen)subScreens[(int)m_viewingState]).ScreenViewLost();
		((SubScreen)subScreens[(int)_newState]).ScreenViewGained();

		if (screenPositions[(int)_newState] == screenPositions[(int)m_viewingState])
		{
			m_viewingState = _newState;
			return;
		}

		// Move our new screen to our right
		screenPositions[(int)_newState].position = new Vector3(_fromRight ? 1 : -1, 0, screenPositions[(int)_newState].position.z);
		oldScreen = screenPositions[(int)m_viewingState];
		oldScreenTarget = new Vector3(_fromRight ? -1 : 1, 0, oldScreen.position.z);
		m_viewingState = _newState;

		animating = true;
	}

	void Update()
	{
		Vector2 currentPos = screenPositions[(int)m_viewingState].position;
		Vector2 targetPos = m_camera.transform.position;

		if (currentPos != targetPos)
		{
			float currentDistance = (targetPos - currentPos).magnitude;
			float distanceToTravel = m_transitionSpeed * Time.deltaTime;
			if (distanceToTravel >= currentDistance)
			{
				distanceToTravel = currentDistance;
				animating = false;
			}
			Vector2 direction = (targetPos - currentPos).normalized;
			Vector2 newPos = currentPos + direction * distanceToTravel;

			// Move new screen in
			screenPositions[(int)m_viewingState].position = new Vector3(newPos.x, newPos.y, screenPositions[(int)m_viewingState].position.z);

			// Move old screen out
			if (oldScreen)
				oldScreen.position = oldScreen.position+ (oldScreenTarget - oldScreen.position).normalized * distanceToTravel;

			// Colour
			Color currentColour = m_camera.backgroundColor;
			Color targetColour = screenColours[(int)m_viewingState];
			float fractionChange = distanceToTravel/currentDistance;
			Color newColour = new Color(Mathf.Lerp(currentColour.r,targetColour.r,fractionChange),
				Mathf.Lerp(currentColour.g,targetColour.g,fractionChange),
				Mathf.Lerp(currentColour.b,targetColour.b,fractionChange));
			m_camera.backgroundColor = newColour;
		}
		else
		{
			animating = false;
		}
	}

}
