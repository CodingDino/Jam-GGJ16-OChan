using UnityEngine;
using System.Collections;

public class SugarBowl : MonoBehaviour {

	public int maxCubes = 6;
	public Animator[] cubeAnimator;
	public Animator bowlAnimator;
	public Animator arrowAnimator;
	public Gauge gauge;

	void Update()
	{
		if (ScreenManager.GetViewingState() != GameState.SUGAR)
			return;
		
		arrowAnimator.SetBool("loop", TeaManager.instance.sugar != 0);
		bowlAnimator.SetBool("loop", TeaManager.instance.sugar == 0);
		gauge.m_currentValue = TeaManager.instance.sugar;
	}

	void OnMouseUpAsButton() {
		++TeaManager.instance.sugar;
		if (TeaManager.instance.sugar > maxCubes)
			TeaManager.instance.sugar = maxCubes;
		cubeAnimator[TeaManager.instance.sugar - 1].SetTrigger("bounce");
	}
}
