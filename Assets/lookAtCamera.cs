using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour {

    public GameObject camFocus;

	// Use this for initialization
	
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.LookAt(camFocus.transform);	
	}
}
