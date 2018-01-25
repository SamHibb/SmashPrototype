﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public float radius;
    public float strenght = 10;
    private Vector2 normalVec = new Vector2(1, 1);


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown("l"))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.gameObject.transform.position, radius);

            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    if (hitColliders[i].transform.root != this.gameObject.transform)
                    {

                        Rigidbody2D rb = hitColliders[i].gameObject.GetComponent<Rigidbody2D>();
                        var opposite = this.gameObject.GetComponent<Rigidbody2D>().velocity;
                        rb.AddForce((opposite + normalVec) * strenght);
                        Debug.Log("Attack");
                    }
                }
                i++;
            }
        }

    }
}
