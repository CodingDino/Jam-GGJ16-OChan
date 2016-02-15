using UnityEngine;
using System.Collections;

public class CustomerBody : MonoBehaviour {

	private Customer m_data;

	public SpriteRenderer m_Face;
	public SpriteRenderer m_Shirt;
	public SpriteRenderer m_speechIcon;
	public SpriteRenderer m_greeting;

	public GameObject[] m_Temps;

	public Animator m_customerEntryAnimator;
	public Animator m_greetingAnimator;
	public Animator m_speechAnimator;
	public Animator m_teaAnimator;

	public Sprite[] m_Faces;
	public Sprite[] m_Shirts;
	public Sprite[] m_Orders;
	public Sprite[] m_Greetings;
	public Sprite[] m_TeaFeatures;

	public SpriteRenderer[] m_hearts;
	public Color[] m_heartColours;
	public Animator[] m_heartAnimators;

	public Animator m_badAnimator;

	public void SetCustomerData(Customer _data)
	{
		m_data = _data;
		// Update image to match data
		m_Face.sprite = m_Faces[m_data.GetSection(TeaFeature.SUGAR)];
		m_Shirt.sprite = m_Shirts[m_data.GetSection(TeaFeature.CUP)];
		for(int i = 0; i < m_Temps.Length; ++i)
		{
			m_Temps[i].SetActive( i == m_data.GetSection(TeaFeature.TEMP));
		}
		m_speechIcon.sprite = m_Orders[m_data.GetSection(TeaFeature.TYPE)];
		m_greeting.sprite = m_Greetings[m_data.GetSection(TeaFeature.STRENGTH)];
	}

	public IEnumerator Enter()
	{
		m_customerEntryAnimator.SetBool("show",true);
		yield return new WaitForSeconds(1);
	}

	public IEnumerator PerformGreeting()
	{
		m_greetingAnimator.SetBool("show",true);
		yield return new WaitForSeconds(0.5f);
	}

	public IEnumerator DisplaySpeechBubble()
	{
		m_speechAnimator.SetBool("show",true);
		yield return new WaitForSeconds(0.5f);
	}

	public IEnumerator HidePrompts()
	{
		m_greetingAnimator.SetBool("show",false);
		m_speechAnimator.SetBool("show",false);
		yield return new WaitForSeconds(0.5f);
	}

	public IEnumerator DrinkTea()
	{
		float teaDrinkTime = 2;
		int score = 0;

		// Drink tea and display score for each stage

		// Temp
		m_teaAnimator.SetTrigger("drink");
		yield return new WaitForSeconds(teaDrinkTime);
		score = m_data.EvalTemp(TeaManager.instance.temperature);
		yield return StartCoroutine(GiveFeedback(score, TeaFeature.TEMP));

		// Type
		m_teaAnimator.SetTrigger("drink");
		yield return new WaitForSeconds(teaDrinkTime);
		score = m_data.EvalType(TeaManager.instance.type);
		yield return StartCoroutine(GiveFeedback(score, TeaFeature.TYPE));

		// Strength
		m_teaAnimator.SetTrigger("drink");
		yield return new WaitForSeconds(teaDrinkTime);
		score = m_data.EvalStrength(TeaManager.instance.strength);
		yield return StartCoroutine(GiveFeedback(score, TeaFeature.STRENGTH));

		// Cup
		m_teaAnimator.SetTrigger("drink");
		yield return new WaitForSeconds(teaDrinkTime);
		score = m_data.EvalCup(TeaManager.instance.cup);
		yield return StartCoroutine(GiveFeedback(score, TeaFeature.CUP));

		// Sugar
		m_teaAnimator.SetTrigger("drink");
		yield return new WaitForSeconds(teaDrinkTime);
		score = m_data.EvalSugar(TeaManager.instance.sugar);
		yield return StartCoroutine(GiveFeedback(score, TeaFeature.SUGAR));

		yield return null;
	}

	public IEnumerator GiveFeedback(int _score, TeaFeature _feature)
	{
		Debug.Log("Score for "+_feature+" is "+_score);
		m_speechIcon.sprite = m_TeaFeatures[(int)_feature];
		m_speechAnimator.SetBool("show",true);
		yield return new WaitForSeconds(1);
		for(int i = 0; i < _score; ++i)
		{
			m_hearts[i].color = m_heartColours[(int)_feature];
			m_heartAnimators[i].SetTrigger("show");
			yield return new WaitForSeconds(0.2f);
		}
		if (_score == 0)
		{
			m_badAnimator.SetBool("show",true);
			yield return new WaitForSeconds(2.5f);
			m_badAnimator.SetBool("show",false);
			yield return new WaitForSeconds(0.5f);
		}
		else
		{
			yield return new WaitForSeconds(3);
		}
		m_speechAnimator.SetBool("show",false);

		yield return null;
	}

	public void Exit()
	{
		m_customerEntryAnimator.SetBool("show",false);
	}


}
