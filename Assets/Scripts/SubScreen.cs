using UnityEngine;
using System.Collections;

public interface SubScreen {
	
	void ScreenViewGained();
	void ScreenViewLost();
	void ScreenFocusGained();
	void ScreenFocusLost();

}
