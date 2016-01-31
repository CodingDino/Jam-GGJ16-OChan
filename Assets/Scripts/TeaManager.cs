using UnityEngine;
using System.Collections;

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
	CANDY,
	//--
	NUM
}

public class TeaManager : Singleton<TeaManager> {

	public float temperature;
	public TeaType type = TeaType.NONE;
	public float strength;
	public CupType cup = CupType.NONE;
	public int sugar;

	public static void Reset()
	{
		instance.temperature = 0;
		instance.type = TeaType.NONE;
		instance.strength = 0;
		instance.cup = CupType.NONE;
		instance.sugar = 0;
	}
}
