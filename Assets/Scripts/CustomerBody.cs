using UnityEngine;
using System.Collections;

public class CustomerBody : MonoBehaviour {

	Customer m_data;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetCustomerData(Customer _data)
	{
		m_data = _data;
		// TODO: Update image to match data
	}

	public void Enter()
	{
		// TODO: Enter the shop (fade in?)
	}

	public void PerformGreeting()
	{
		// TODO: Perform customer greeting
	}

	public void DisplaySpeechBubble()
	{
		// TODO: Show customer speech bubble
	}

	public void DrinkTea()
	{
		// TODO: Drink tea and display score for each stage

		// TODO: Customer looks at cup

		// Cup
		int score = m_data.EvalCup(TeaManager.instance.cup);
		GiveFeedback(score, TeaFeature.CUP);

		// TODO: Customer smells tea

		// Type
		score = m_data.EvalType(TeaManager.instance.type);
		GiveFeedback(score, TeaFeature.TYPE);

		// TODO: Customer sips tea

		// Temp
		score = m_data.EvalTemp(TeaManager.instance.temperature);
		GiveFeedback(score, TeaFeature.TEMP);

		// TODO: Customer sips tea

		// Temp
		score = m_data.EvalTemp(TeaManager.instance.strength);
		GiveFeedback(score, TeaFeature.STRENGTH);

		// TODO: Customer drains mug

		// Sugar
		score = m_data.EvalSugar(TeaManager.instance.sugar);
		GiveFeedback(score, TeaFeature.SUGAR);
	}

	public void GiveFeedback(int Score, TeaFeature _feature)
	{
		// TODO: Display feedback above customer's head in speech bubble
		// TODO: Spawn "score" hearts.

		// TODO: Cute custom animations for each of these
	}

	public void Exit()
	{
		// TODO: Exit the shop (fade out?)
	}


}
