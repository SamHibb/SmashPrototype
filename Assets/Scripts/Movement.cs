using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float maxVelocity = 10;
    public float jumpForce = 4.0f;
    public float walkForce = 4.0f;
    private float x = 0;
    private float y = 0;
    private bool isGrounded = true;

    public float fall_speed = 1;

    public int player_no = 0;

    private Vector3 collisionPoint;

    private string player_string;

    private Rigidbody2D rb;
    private SpriteRenderer spr;

    private int orientation = 1;

    private void Start()
    {
        player_string = "P" + player_no.ToString();
        Debug.Log(player_string);

        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
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
            orientation = 1;
            transform.localScale = new Vector3(1, 1, 1);
            //spr.flipX = true;
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

            transform.localScale = new Vector3(-1, 1, 1);
            orientation = -1;
            //spr.flipX = false;
        }

        if (Input.GetAxis(player_string + "Vertical") < -0.1f)
        {
            if (gameObject.transform.parent.tag == "MovingPlatform")
            {
                gameObject.transform.Translate(0, -0.5f, 0);
            }
        }

        if (Input.GetButtonDown(player_string + "A") && isGrounded)
        {
            Debug.Log(player_string + " " + player_no);
            jump(); 
        }

        //this moves the player

        rb.AddForce(new Vector2(x, y) * walkForce, ForceMode2D.Impulse);
        dampenForces();
        //dampenForces();

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fall_speed;
        }
        else
        {
            rb.gravityScale = 1;
        }

        // limiting rb velocity just for testing purposes
        if (rb.velocity.sqrMagnitude > maxVelocity)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rb.velocity *= 0.99f;
        }

        //Debug.Log(rb.velocity + "velocity");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            collisionPoint = collision.contacts[0].point;
            isGrounded = true;
            y = 0;
        }
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

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}

    public int GetOrientation()
    {
        return orientation;
    }



}
