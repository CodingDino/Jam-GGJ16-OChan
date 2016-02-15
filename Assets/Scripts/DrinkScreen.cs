using UnityEngine;
using System.Collections;

public class DrinkScreen : MonoBehaviour, SubScreen {

	public GameObject teaObject;
	public GameObject arrowObject;
	public GameObject customerObject;
	public Animator arrowAnimator;
	public CustomerBody customerBody;

	private bool customerDoneDrinking = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScreenManager.GetViewingState() != GameState.ORDER)
			return;

		arrowObject.SetActive(customerDoneDrinking);
		arrowAnimator.SetBool("loop", customerDoneDrinking);
	}

	public void ScreenViewGained() {
		customerObject.SetActive(false);
		teaObject.SetActive(true);
	}
	public void ScreenViewLost() {
		customerObject.SetActive(true);
		teaObject.SetActive(false);
	}
	public void ScreenFocusGained() {
		customerDoneDrinking = false;
		StartCoroutine(CustomerRatingSequence());
	}
	public void ScreenFocusLost() {
		StartCoroutine(customerBody.HidePrompts());
		customerBody.Exit();
	}

	public IEnumerator CustomerRatingSequence()
	{
		yield return customerBody.HidePrompts();
		yield return StartCoroutine(customerBody.DrinkTea());
		customerDoneDrinking = true;
	}
}
