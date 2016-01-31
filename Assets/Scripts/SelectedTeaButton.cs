using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SelectedTeaButton : MonoBehaviour {

	public SpriteRenderer overlay;
	public Collider2D buttonCollider;
	public SpriteRenderer button;
	public SpriteRenderer icon;

	public List<Sprite> icons;

	public List<Color> colors;

	public Animator m_arrowAnimator;
	public GameObject m_arrowObject;

	public EventSystem m_eventSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScreenManager.GetViewingState() != GameState.TEA)
			return;

		bool hasSelectedTea = TeaManager.instance.type != TeaType.NONE;
		overlay.enabled = hasSelectedTea;
		button.enabled = hasSelectedTea;
		buttonCollider.enabled = hasSelectedTea;
		icon.enabled = hasSelectedTea;

		if (hasSelectedTea)
		{
			icon.sprite = icons[(int)TeaManager.instance.type];
			button.color = colors[(int)TeaManager.instance.type];
		}
			
		m_arrowAnimator.SetBool("loop", hasSelectedTea);
		m_arrowObject.SetActive(hasSelectedTea);
	}

	void OnMouseDown() {
		if (ScreenManager.GetViewingState() != GameState.TEA)
			return;
		
		if (!m_eventSystem.IsPointerOverGameObject()) // Prevents UI click through
			TeaManager.instance.type = TeaType.NONE;
	}
}
