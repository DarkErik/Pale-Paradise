using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	public static Factory instance;

	public LayerMask lightInteractor;
    private void Start()
    {
		instance = this;
    }

}
