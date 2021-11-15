using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for utility functions
 * 
 */
public static class Util
{

	public static Vector2 AngleDegToVector(float angleDEG) {
		angleDEG *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(angleDEG), Mathf.Sin(angleDEG));
	}

}
