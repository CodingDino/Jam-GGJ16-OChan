using UnityEngine;
using System.Collections;

public enum TeaType {
	NONE = -1,
	FISH = 0,
	PEACH,
	CANDY
}

public enum CupType {
	NONE = -1,
	FISH = 0,
	PEACH,
	CANDY
}

public class TeaManager : Singleton<TeaManager> {

	public float temperature;
	public TeaType type = TeaType.NONE;
	public float strength;
	public CupType cup = CupType.NONE;
}
