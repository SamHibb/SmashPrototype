using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusMovement : MonoBehaviour {

    Vector3 focusPostion;
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 averageCenter = Vector3.zero;
        Vector3 position = Vector3.zero;

        for (int i = 0; i < "players_joined"; i++)
        {
            Vector3 pPosition = "Players[i]".transform.postion;
        }
        position += pPosition;
        focusPostion = (position / players_joined);

        transform.position = focusPostion;
    }
}
// need to call spawn player function
// need plays_joind and Players vairables.
