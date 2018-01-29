using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helth : MonoBehaviour {

    public int helth = 0;
    public Text helthText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        helthText.text = (helth + "%");
	}
    
}
