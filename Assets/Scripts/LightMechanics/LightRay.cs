using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightRay : MonoBehaviour
{
	public static readonly int MAX_BOUNCES = 100;

	[SerializeField] private LineRenderer lineRenderer;
	public float startRotation;

	public void Update() {
		Vector2 position = transform.position;
		float angle = startRotation;

		LinkedList<Vector3> lineRendererVerts = new LinkedList<Vector3>();
		lineRendererVerts.AddFirst(position);

		int bounces = 0;
		bool reflect;
		RaycastHit2D[] results;
		Collider2D lastReflectedCollider = null;

		do {
			reflect = false;

			results = Physics2D.RaycastAll(position, Util.AngleDegToVector(angle), 1000, Factory.instance.lightInteractor);

			RaycastHit2D result = results[0].collider == lastReflectedCollider ? results[1] : results[0];


			if (result) {
				LightInteractor interactor = result.collider.gameObject.GetComponent<LightInteractor>();

				LightInteractor.LightReflection reflection = interactor.GetReflection(angle);
				if (reflection.IsReflecting()) {
					if (++bounces <= MAX_BOUNCES && !lineRendererVerts.Contains(reflection.reflectionPosition))
						reflect = true;
					position = reflection.reflectionPosition;
					angle = reflection.angle;
					lineRendererVerts.AddLast(position);

					lastReflectedCollider = result.collider;
				}

				interactor.OnLightHit();

			} else {
				Debug.LogWarning("IMPLEMENT CODE HERE");
			}
		} while (reflect);

		//Debug.Log(Util.AngleDegToVector(startRotation));

		lineRendererVerts.AddLast((results[0].collider == lastReflectedCollider ? results[1] : results[0]).point);

		lineRenderer.positionCount = lineRendererVerts.Count;
		lineRenderer.SetPositions(lineRendererVerts.ToArray());
	}

}
