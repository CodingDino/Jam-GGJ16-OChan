using UnityEngine;
using System.Collections;

public class OrderScreen : MonoBehaviour, SubScreen {

	public GameObject arrowObject;
	public GameObject customerObject;
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

	public void ScreenViewGained() {
		customerObject.SetActive(false);
	}
	public void ScreenViewLost() {
		customerObject.SetActive(true);
	}
	public void ScreenFocusGained() {
		customerAnimationFinished = false;
		StartCoroutine(CustomerEntrySequence());
	}
	public void ScreenFocusLost() {
	}

	public IEnumerator CustomerEntrySequence()
	{
		// Set up customer looks to match their needs
		yield return new WaitForSeconds(1.5f);
		TeaManager.Reset();
		customerBody.SetCustomerData(TeaManager.instance.currentCustomer);
		yield return StartCoroutine(customerBody.Enter());
		yield return StartCoroutine(customerBody.PerformGreeting());
		yield return StartCoroutine(customerBody.DisplaySpeechBubble());

		customerAnimationFinished = true;
	}
}
