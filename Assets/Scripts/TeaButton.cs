using UnityEngine;
using System.Collections;

public class TeaButton : MonoBehaviour {

	public TeaType type;

	void OnMouseDown()
	{
		TeaManager.instance.type = type;
	}
}
