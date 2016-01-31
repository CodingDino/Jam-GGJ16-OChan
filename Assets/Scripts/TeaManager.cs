using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TeaType {
	NONE = -1,
	FISH = 0,
	PEACH,
	CANDY,
	//--
	NUM
}

public enum CupType {
	NONE = -1,
	FISH = 0,
	PEACH,
	HEART,
	//--
	NUM
}

public enum TeaFeature {
	NONE = -1,
	//--
	TEMP = 0,
	TYPE,
	STRENGTH,
	CUP,
	SUGAR
}

public struct Score {
	public int temperature;
	public int type;
	public int strength;
	public int cup;
	public int sugar;
}

public class TeaManager : Singleton<TeaManager> {

	public float temperature;
	public TeaType type = TeaType.NONE;
	public float strength;
	public CupType cup = CupType.NONE;
	public int sugar;

	public Customer currentCustomer = new Customer();

	public List<Score> scores = new List<Score>();

	public static void Reset()
	{
		instance.temperature = 0;
		instance.type = TeaType.NONE;
		instance.strength = 0;
		instance.cup = CupType.NONE;
		instance.sugar = 0;

		instance.currentCustomer.Randomise();
	}

	public static void RecordScore()
	{
		Score currentScore;

		currentScore.temperature = instance.currentCustomer.EvalTemp(instance.temperature);
		currentScore.type = instance.currentCustomer.EvalType(instance.type);
		currentScore.strength = instance.currentCustomer.EvalStrength(instance.strength);
		currentScore.cup = instance.currentCustomer.EvalCup(instance.cup);
		currentScore.sugar = instance.currentCustomer.EvalSugar(instance.sugar);

		instance.scores.Add(currentScore);
	}
}
