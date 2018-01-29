using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public int min_x, max_x, min_y, max_y;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x > max_x || transform.position.x < min_x || transform.position.y < min_y || transform.position.y > max_y)
        {
            transform.position = new Vector2(0, 0);
            this.GetComponent<Damage>().resetDamageMul();
        }

    }
}
