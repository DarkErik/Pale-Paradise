using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightInteractor : MonoBehaviour
{

	public abstract LightReflection GetReflection(float angle);
	public abstract void OnLightHit();
		

	public struct LightReflection {
		public static LightReflection NOT_REFLECTING = new LightReflection(-Vector2.one, 0);

		public LightReflection(Vector2 reflectionPosition, float angle) {
			this.reflectionPosition = reflectionPosition;
			this.angle = angle;
		}

		public Vector2 reflectionPosition;
		public float angle;

		public bool IsReflecting() {
			return reflectionPosition != NOT_REFLECTING.reflectionPosition;
		}
	}
}
