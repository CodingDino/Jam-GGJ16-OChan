using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedCupButton : MonoBehaviour {

	public SpriteRenderer overlay;
	public Collider2D buttonCollider;
	public SpriteRenderer button;

	public List<Color> colors;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool hasSelection = TeaManager.instance.cup != CupType.NONE;
		overlay.enabled = hasSelection;
		button.enabled = hasSelection;
		buttonCollider.enabled = hasSelection;

		if (hasSelection)
		{
			button.color = colors[(int)TeaManager.instance.cup];
		}
	}

	void OnMouseDown() {
		TeaManager.instance.cup = CupType.NONE;
	}
}
