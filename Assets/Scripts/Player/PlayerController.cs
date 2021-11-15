using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	[SerializeField] private float speed = 1;

	private void Start() {
		instance = this;
	}

	public void FixedUpdate() {
		Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (moveDir != Vector2.zero) {
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg);
			transform.position += speed * Time.fixedDeltaTime * transform.right;
		}
		
	}
}
