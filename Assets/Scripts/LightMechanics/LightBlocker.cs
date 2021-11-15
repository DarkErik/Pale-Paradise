using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlocker : LightInteractor {
	public override LightReflection GetReflection(float angle) {
		return LightInteractor.LightReflection.NOT_REFLECTING;
	}

	public override void OnLightHit() {
		
	}
}
