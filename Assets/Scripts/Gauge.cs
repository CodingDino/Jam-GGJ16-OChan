using UnityEngine;
using System.Collections;

public class Gauge : MonoBehaviour {

	[SerializeField]
	private Transform m_fill;
	[SerializeField]
	private float m_maxScale = 1;
	[SerializeField]
	private float m_minValue = 0;
	[SerializeField]
	private float m_maxValue = 100;

	public float m_currentValue = 0;

	void Update()
	{
		float targetScale = Mathf.Lerp(0,m_maxScale,(m_currentValue-m_minValue)/(m_maxValue-m_minValue));

		m_fill.transform.localScale = new Vector3(targetScale, m_fill.transform.localScale.y, m_fill.transform.localScale.z);
	}

}
