using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMirror : LightInteractor {
	[SerializeField] private bool isDoubleSidedMirror = false;
	[SerializeField] private bool reflectsLightAxisaligned = true;


	public override LightReflection GetReflection(float angle) {
		

		angle = (angle + 360) % 360;

		float reflectionAngle = GetReflectionAngle(angle);

		if (reflectionAngle == -1 && isDoubleSidedMirror) reflectionAngle = GetReflectionAngle(angle, 180);

		if (reflectionAngle == -1) {
			return LightReflection.NOT_REFLECTING;
		} else {
			return new LightReflection(transform.position, reflectionAngle);
		}
	}

	private float GetReflectionAngle(float angle, float simulateAdditionalRotation = 0) {
		float reflectionAngle = -1;

		if (!reflectsLightAxisaligned) {
			angle -= 45;
			angle = (angle + 360) % 360;
		}

		switch (transform.rotation.eulerAngles.z + simulateAdditionalRotation) {
			case 0:
				switch (angle) {
					case 270:
						reflectionAngle = 0;
						break;
					case 180:
						reflectionAngle = 90;
						break;
				}
				break;

			case 90:
				switch (angle) {
					case 180:
						reflectionAngle = 270;
						break;
					case 90:
						reflectionAngle = 0;
						break;
				}
				break;

			case 180:
				switch (angle) {
					case 90:
						reflectionAngle = 180;
						break;
					case 0:
						reflectionAngle = 270;
						break;
				}
				break;

			case 270:
				switch (angle) {
					case 0:
						reflectionAngle = 90;
						break;
					case 270:
						reflectionAngle = 180;
						break;
				}
				break;
		}

		if (!reflectsLightAxisaligned && reflectionAngle != -1) {
			reflectionAngle += 45;
			reflectionAngle = (reflectionAngle + 360) % 360;
		}

		return reflectionAngle;
	}

	public override void OnLightHit() {
		
	}
}
