using UnityEngine;
using System.Collections;

public class SugarBowl : MonoBehaviour {

	public int maxCubes = 6;
	public Animator[] cubeAnimator;
	public Animator bowlAnimator;
	public Animator arrowAnimator;
	public Gauge gauge;

	void OnMouseUpAsButton() {
		++TeaManager.instance.sugar;
		if (TeaManager.instance.sugar > maxCubes)
			TeaManager.instance.sugar = maxCubes;
		gauge.m_currentValue = TeaManager.instance.sugar;
		cubeAnimator[TeaManager.instance.sugar - 1].SetTrigger("bounce");
		bowlAnimator.SetBool("loop", false);
		arrowAnimator.SetBool("loop", true);
	}
}
