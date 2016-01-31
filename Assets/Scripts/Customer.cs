using UnityEngine;
using System.Collections;

public class Customer {

	public float temperature;
	public TeaType type;
	public float strength;
	public CupType cup;
	public int sugar;

	private const int FULL_MARKS = 2;
	private const int PARTIAL_MARKS = 1;

	public int EvalTemp(float _teaTemp)
	{
		float diff = Mathf.Abs(_teaTemp - temperature);
		if (diff <= 10)
		{
			return FULL_MARKS;
		}
		else if (diff <= 20)
		{
			return PARTIAL_MARKS;
		}
		return 0;
	}

	public int EvalType(TeaType _teaType)
	{
		if (_teaType == type)
		{
			return FULL_MARKS;
		}
		return 0;
	}

	public int EvalStrength(float _teaStrength)
	{
		float diff = Mathf.Abs(_teaStrength - strength);
		if (diff <= 10)
		{
			return FULL_MARKS;
		}
		else if (diff <= 20)
		{
			return PARTIAL_MARKS;
		}
		return 0;
	}

	public int EvalCup(CupType _teaCup)
	{
		if (_teaCup == cup)
		{
			return FULL_MARKS;
		}
		return 0;
	}

	public int EvalSugar(int _teaSugar)
	{
		float diff = Mathf.Abs(_teaSugar - sugar);
		if (diff <= 1)
		{
			return FULL_MARKS;
		}
		else if (diff <= 2)
		{
			return PARTIAL_MARKS;
		}
		return 0;
	}

	public void Randomise()
	{
		temperature = Random.Range(0,3)*20 + 10; // 10, 30, 50 (0-60)
		type = (TeaType) UnityEngine.Random.Range(0,(int)TeaType.NUM);
		strength = Random.Range(0,3)*20 + 10; // 10, 30, 50 (0-60)
		cup = (CupType) UnityEngine.Random.Range(0,(int)CupType.NUM);
		sugar = Random.Range(0,3)*2 + 1; // 1, 3, 5 (0-6)
	}
}
