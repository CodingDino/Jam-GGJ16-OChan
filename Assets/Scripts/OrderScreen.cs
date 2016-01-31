using UnityEngine;
using System.Collections;

public class OrderScreen : MonoBehaviour, SubScreen {

	public GameObject arrowObject;
	public Animator arrowAnimator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScreenViewGained() {
		// TODO: TEMP!
		arrowObject.SetActive(true);
		arrowAnimator.SetBool("loop", true);
	}
	public void ScreenViewLost() {}
	public void ScreenFocusGained() {
		TeaManager.Reset();
	}
	public void ScreenFocusLost() {}
}
