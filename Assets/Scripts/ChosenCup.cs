using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChosenCup : MonoBehaviour {

	public List<Sprite> sprites;
	public SpriteRenderer toSprite;
	
	// Update is called once per frame
	void Update () {

		bool hasSelection = TeaManager.instance.cup != CupType.NONE;

		if (hasSelection)
		{
			toSprite.sprite = sprites[(int)TeaManager.instance.cup];
		}
	
	}
}
