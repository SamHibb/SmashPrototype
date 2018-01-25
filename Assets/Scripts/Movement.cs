using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float jumpForce = 4.0f;
    public float walkForce = 4.0f;
    private float x = 0;
    private float y = 0;
    private bool isGrounded = true;

    private Vector3 collisionPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            if (isGrounded)
            {
                x -= 0.1f;
            }
            else
            {
                x -= 0.05f;
            }
        }

        if (Input.GetKey("d"))
        {
            if (isGrounded)
            {
                x += 0.1f;
            }
            else
            {
                x += 0.05f;
            }
        }

        if (Input.GetKey("space") && isGrounded)
        {
            jump(); 
        }

        //transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(x, y, 0), 1.0f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * walkForce, ForceMode2D.Impulse);

        if (x > 0)
        {
            x -= 0.1f;
        }
        else if (x < 0)
        {
            x += 0.1f;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        collisionPoint = collision.contacts[0].point;
        isGrounded = true;
    }


    private void jump()
    {
        if (collisionPoint.y > -0.1)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2((collisionPoint.x / 10), 1) * jumpForce, ForceMode2D.Impulse);
        }
        isGrounded = false;
    }
}
