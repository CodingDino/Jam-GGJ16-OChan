using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedTeaButton : MonoBehaviour {

	public SpriteRenderer overlay;
	public Collider2D buttonCollider;
	public SpriteRenderer button;
	public SpriteRenderer icon;

	public List<Sprite> icons;

	public List<Color> colors;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
	}

	void OnMouseDown() {
		TeaManager.instance.type = TeaType.NONE;
	}
}
