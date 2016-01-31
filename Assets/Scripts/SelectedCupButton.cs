using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SelectedCupButton : MonoBehaviour {

	public SpriteRenderer overlay;
	public Collider2D buttonCollider;
	public SpriteRenderer button;

	public List<Color> colors;

	public Animator m_arrowAnimator;
	public GameObject m_arrowObject;

	public EventSystem m_eventSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScreenManager.GetViewingState() != GameState.CUP)
			return;
		
		bool hasSelection = TeaManager.instance.cup != CupType.NONE;
		overlay.enabled = hasSelection;
		button.enabled = hasSelection;
		buttonCollider.enabled = hasSelection;

		if (hasSelection)
		{
			button.color = colors[(int)TeaManager.instance.cup];
		}

		m_arrowAnimator.SetBool("loop", hasSelection);
		m_arrowObject.SetActive(hasSelection);
	}

	void OnMouseDown() {
		if (!m_eventSystem.IsPointerOverGameObject()) // Prevent UI Click through
			TeaManager.instance.cup = CupType.NONE;
	}
}
