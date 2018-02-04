using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platforms : MonoBehaviour {

    public bool moving;
	public float min_height;
	public float max_height;
	public bool switch_axis = false;
	private float current_pos_x;
	private float current_pos_y;
	private bool updown = true;
	// Use this for initialization
	void Start () 
	{
		current_pos_y = transform.position.y;
		current_pos_x = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (moving == true)
        {
            if (switch_axis)
            {
                if (current_pos_x > max_height)
                {
                    updown = false;
                }
                if (current_pos_x < min_height)
                {
                    updown = true;
                }

                if (updown)
                {
                    current_pos_x += 0.03f;
                }
                else
                {
                    current_pos_x -= 0.03f;
                }
            }
            else
            {
                if (current_pos_y > max_height)
                {
                    updown = false;
                }
                if (current_pos_y < min_height)
                {
                    updown = true;
                }

                if (updown)
                {
                    current_pos_y += 0.03f;
                }
                else
                {
                    current_pos_y -= 0.03f;
                }
            }
        }

		transform.position = new Vector2(current_pos_x, current_pos_y);
	}
}
