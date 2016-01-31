using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour {

	private bool buttonDown = false;

	public float increaseRate = 1;
	public float max = 100;
	public Animator buttonAnimator;
	public Gauge m_gauge;
	public Animator nextArrowAnimator;
	public GameObject nextArrowObject;
	public Animator teaBagAnimator;

	public SpriteRenderer teabag;
	public SpriteRenderer icon;

	public Color[] colors;
	public Sprite[] sprites;

	void Update()
	{
		if (ScreenManager.GetViewingState() != GameState.BREW)
			return;
		
		if (buttonDown)
		{
			float increase = increaseRate * Time.deltaTime;
			TeaManager.instance.strength += increase;
			if (TeaManager.instance.strength > max)
				TeaManager.instance.strength = max;
		}

		m_gauge.m_currentValue = TeaManager.instance.strength;
		nextArrowAnimator.SetBool("loop", TeaManager.instance.strength != 0);
		nextArrowObject.SetActive(TeaManager.instance.strength != 0);

		teabag.color = colors[(int)TeaManager.instance.type];
		icon.sprite = sprites[(int)TeaManager.instance.type];
	}

	void OnMouseDown()
	{
		buttonDown = true;
		buttonAnimator.SetBool("loop", false);
		teaBagAnimator.SetBool("brew", true);
	}

	void OnMouseUp()
	{
		if(buttonDown)
		{
			buttonDown = false;
			teaBagAnimator.SetBool("brew", false);
		}
	}
}
