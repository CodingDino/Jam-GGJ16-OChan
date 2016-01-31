using UnityEngine;
using System.Collections;

public class KettleButton : MonoBehaviour {

	private bool buttonDown = false;

	public float increaseRate = 1;
	public float max = 100;
	public Animator buttonAnimator;
	public Gauge m_gauge;
	public SpriteRenderer m_burner;
	public Animator nextArrowAnimator;


	void Update()
	{
		if (buttonDown)
		{
			float increase = increaseRate * Time.deltaTime;
			TeaManager.instance.temperature += increase;
			if (TeaManager.instance.temperature > max)
				TeaManager.instance.temperature = max;
			m_gauge.m_currentValue = TeaManager.instance.temperature;
		}
	}

	void OnMouseDown()
	{
		buttonDown = true;
		m_burner.enabled = true;
		buttonAnimator.SetBool("loop", false);
		buttonAnimator.SetBool("grow", false);
	}

	void OnMouseUp()
	{
		if(buttonDown)
		{
			buttonDown = false;
			m_burner.enabled = false;
			buttonAnimator.SetBool("grow", true);
			nextArrowAnimator.SetBool("loop", true);
		}
	}

}
