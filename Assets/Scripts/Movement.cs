using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float jumpForce = 4.0f;
    public float walkForce = 4.0f;
    private float x = 0;
    private float y = 0;
    private bool isGrounded = true;

    public int player_no = 0;

    private Vector3 collisionPoint;

    private string player_string;

    private void Start()
    {
        player_string = "P" + player_no.ToString();
        Debug.Log(player_string);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis(player_string + "Horizontal") > 0.1f)
        {
            if (isGrounded)
            {
                x += 0.1f;
            }
            else
            {
                x += 0.08f;
            }
        }

        else if (Input.GetAxis(player_string + "Horizontal") < -0.1f)
        {
            if (isGrounded)
            {
                x -= 0.1f;
            }
            else
            {
                x -= 0.08f;
            }
        }

        if (Input.GetButtonDown(player_string + "A") && isGrounded)
        {
            Debug.Log(player_string + " " + player_no);
            jump(); 
        }

        //this moves the player
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * walkForce, ForceMode2D.Impulse);

        dampenForces();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        collisionPoint = collision.contacts[0].point;
        isGrounded = true;
        y = 0;
    }


    private void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        //so onCollisionStay isn't immediately triggered
        transform.Translate(0, 0.01f, 0);
        isGrounded = false;
    }

    private void dampenForces()
    {
        if (x > 0)
        {
            x -= 0.1f;
        }
        else if (x < 0)
        {
            x += 0.1f;
        }

        if (x < 0.1f || x > 0.1f)
        {
            x = 0;
        }

        if (y > 0)
        {
            y -= 0.1f;
        }
    }
}
