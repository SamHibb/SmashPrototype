using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{

    public float chargeTime = 3f;

    public float radius;
    public float strength = 10;
    public int damageMultiplier = 2;
    public int rotation = 1;

    public int player_no = 0;

    private string player_string;

    private float original_strength;

    private Vector2 normalVec = new Vector2(1, 1);
    private float chargingTime = 0;

    void Start()
    {
        player_string = "P" + player_no.ToString();
        Debug.Log(player_string);
    }

    // Update is called once per frame
    void Update()
    {

        rotation = this.GetComponent<Movement>().GetOrientation();

        if (Input.GetButton(player_string + "C") 
            && (this.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0.1 
            && this.gameObject.GetComponent<Rigidbody2D>().velocity.x >= -0.1) 
            && (this.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.1
            && this.gameObject.GetComponent<Rigidbody2D>().velocity.y >= -0.1))
        {
            chargingTime += Time.deltaTime;
            Debug.Log(chargingTime + "chargingtime");

            if (chargingTime > chargeTime)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.gameObject.transform.position, radius);
                ParticleSystem.ShapeModule shapeModule = this.GetComponentInChildren<ParticleSystem>().shape;
                shapeModule.arc = 300f;
                this.GetComponentInChildren<ParticleSystem>().Play();
                int i = 0;
                

                // for colliders within range
                while (i < hitColliders.Length)
                {
                    // continue if found object has a rigidbody
                    if (hitColliders[i].gameObject.GetComponent<Rigidbody2D>() != null)
                    {

                        // make sure it is not the object itself
                        if (hitColliders[i].transform.root != this.gameObject.transform)
                        {

                            Rigidbody2D rb = hitColliders[i].gameObject.GetComponent<Rigidbody2D>();

                            if (rb != gameObject.GetComponent<Rigidbody2D>())
                            {
                                // get damage multiplier of hit object
                                int damageMul = hitColliders[i].gameObject.GetComponent<Damage>().getDamageMul();

                                // get player velocity
                                Vector2 force = hitColliders[i].gameObject.transform.position - this.gameObject.transform.position;
                                force.Normalize();

                                //// if force x is close to 0 set it to 0.5
                                //if (force.x < 0.5 && force.x > -0.5)
                                //{
                                //    force.x = 0.5f * this.GetComponent<Movement>().GetOrientation();
                                //    Debug.Log(force + "force");
                                //}

                                //// if force y is close to 0 set it to 0.5
                                //if (force.y < 0.5 && force.y > -0.5)
                                //{
                                //    force.y = 0.5f; //this.GetComponent<Movement>().GetOrientation();
                                //}

                                // debug shiz
                                {
                                    Debug.Log(damageMul + "mul " + strength + "strength");
                                    Vector2 debugForce = force * strength * damageMul;
                                    Debug.Log(debugForce + "attack force");
                                }

                                if(damageMul == 0)
                                {
                                    damageMul = 1;
                                }
                                Vector2 punch = force * damageMul * strength;

                                //if (punch.x == 0 && punch.y == 0)
                                //{
                                //    punch = new Vector2(1, 1);
                                //}

                                //punch *= strength;
                                // add the force multiplied by strength and damageMul as impluse to the rb
                                rb.AddForce(punch, ForceMode2D.Impulse);

                                // increase damageMultiplier on the player that got hit
                                hitColliders[i].gameObject.GetComponent<Damage>().increaseDamageMul(damageMultiplier);

                                Debug.Log("Attack " + player_string);
                            }
                        }
                    }
                    i++;
                }
                chargingTime = 0;
            }
        }
        else
        {
            chargingTime = 0;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.gameObject.transform.position, radius);
    }

}

