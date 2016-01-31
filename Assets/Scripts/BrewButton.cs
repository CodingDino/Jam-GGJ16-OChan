using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour {

	private bool buttonDown = false;

	public float increaseRate = 1;
	public float max = 100;
	public Animator buttonAnimator;
	public Gauge m_gauge;
	public Animator nextArrowAnimator;
	public Animator teaBagAnimator;


	void Update()
	{
		if (buttonDown)
		{
			float increase = increaseRate * Time.deltaTime;
			TeaManager.instance.strength += increase;
			if (TeaManager.instance.strength > max)
				TeaManager.instance.strength = max;
			m_gauge.m_currentValue = TeaManager.instance.strength;
		}
	}

	void OnMouseDown()
	{
		buttonDown = true;
		buttonAnimator.SetBool("loop", false);
		teaBagAnimator.SetBool("brew", true);
	}

	void OnMouseUp()
	{
		buttonDown = false;
		nextArrowAnimator.SetBool("loop", true);
		teaBagAnimator.SetBool("brew", false);
	}
}
