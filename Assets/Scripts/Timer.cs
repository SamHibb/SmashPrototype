using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeSec = 5;
    public int timeMin = 4;
    public Text contDownText;


	// Use this for initialization
	void Start ()
    {
        StartCoroutine("louseTime");
	}
	
	// Update is called once per frame
	void Update ()
    {
        contDownText.text = ("Time Left = " + timeMin + ":" + timeSec);	
	}

    IEnumerator louseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeSec--;

            if (timeSec == 0 )
            {
                timeMin--;
                timeSec = 60;
            } 
        }
    }
}
