using UnityEngine;
using System.Collections;

public class OrderScreen : MonoBehaviour, SubScreen {

	public GameObject arrowObject;
	public Animator arrowAnimator;
	public CustomerBody customerBody;

	private bool customerAnimationFinished = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScreenManager.GetViewingState() != GameState.ORDER)
			return;
		
		arrowObject.SetActive(customerAnimationFinished);
		arrowAnimator.SetBool("loop", customerAnimationFinished);
	}

	public void ScreenViewGained() {}
	public void ScreenViewLost() {}
	public void ScreenFocusGained() {
		TeaManager.Reset();
		// Set up customer looks to match their needs
		customerBody.SetCustomerData(TeaManager.instance.currentCustomer);
		// TODO: show customer animation
		customerAnimationFinished = true; // TODO: set this AFTER customer animation finishes.
	}
	public void ScreenFocusLost() {}
}
