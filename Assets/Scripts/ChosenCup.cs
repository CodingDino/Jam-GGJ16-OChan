using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChosenCup : MonoBehaviour {

	public List<Color> colors;
	public SpriteRenderer toColor;
	
	// Update is called once per frame
	void Update () {

		bool hasSelection = TeaManager.instance.cup != CupType.NONE;

		if (hasSelection)
		{
			toColor.color = colors[(int)TeaManager.instance.cup];
		}
	
	}
}
