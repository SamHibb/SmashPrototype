using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeSec = 60;
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
        if (timeSec < 10)
        {
            contDownText.text = ("Time Remaining: " + timeMin + ":0" + timeSec);
        }
        else
        {
            contDownText.text = ("Time Remaining: " + timeMin + ":" + timeSec);
        }
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
