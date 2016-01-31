using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class AnimationInitializer : MonoBehaviour {

	[SerializeField]
	private List<string> m_triggers = new List<string>();

	[System.Serializable]
	public struct AnimatorBool
	{
		public string name;
		public bool value;
	}

	[SerializeField]
	private List<AnimatorBool> m_bools = new List<AnimatorBool>();

	[System.Serializable]
	public struct AnimatorFloat
	{
		public string name;
		public float value;
	}

	[SerializeField]
	private List<AnimatorFloat> m_floats = new List<AnimatorFloat>();

	// Use this for initialization
	void Start () {
		Animator animator = GetComponent<Animator>();
		for (int i = 0; i < m_triggers.Count; ++i)
		{
			animator.SetTrigger(m_triggers[i]);
		}
		for (int i = 0; i < m_bools.Count; ++i)
		{
			animator.SetBool(m_bools[i].name, m_bools[i].value);
		}
		for (int i = 0; i < m_floats.Count; ++i)
		{
			animator.SetFloat(m_floats[i].name, m_floats[i].value);
		}
	}
}
