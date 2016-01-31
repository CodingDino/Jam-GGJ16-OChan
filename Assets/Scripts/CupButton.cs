using UnityEngine;
using System.Collections;

public class CupButton : MonoBehaviour {

	public CupType type;

	void OnMouseDown()
	{
		TeaManager.instance.cup = type;
	}
}
