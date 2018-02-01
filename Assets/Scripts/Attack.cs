using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public float radius;
    public float strenght = 10;
    public int damageMultiplier = 6;
    public int rotation = 1;

    public int player_no = 0;

    private string player_string;

    private Vector2 normalVec = new Vector2(1, 1);

    void Start()
    {
        player_string = "P" + player_no.ToString();
        Debug.Log(player_string);
    }

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetButtonDown(player_string + "B"))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.gameObject.transform.position, radius);

            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    if (hitColliders[i].transform.root != this.gameObject.transform)
                    {

                        int damageMul = hitColliders[i].gameObject.GetComponent<Damage>().getDamageMul();
                        Rigidbody2D rb = hitColliders[i].gameObject.GetComponent<Rigidbody2D>();
                        Vector2 force = this.gameObject.GetComponent<Rigidbody2D>().velocity;
                        force.Normalize();
                        if(force.x < 0.5 && force.x > -0.5)
                        {
                            force.x = 0.5f * this.GetComponent<Movement>().GetOrientation();
                            Debug.Log(force + "force");
                        }
                        if (force.y < 0.5 && force.y > -0.5)
                        {
                            force.y = 0.5f; //this.GetComponent<Movement>().GetOrientation();
                        }
                        Debug.Log(damageMul + "mul " + strenght + "strenght");
                        Vector2 debugForce = force * strenght * damageMul;
                        Debug.Log(debugForce + "attack force");
                        rb.AddForce(force * strenght * damageMul, ForceMode2D.Impulse);
                        hitColliders[i].gameObject.GetComponent<Damage>().increaseDamageMul(damageMultiplier);
                        Debug.Log("Attack " + player_string);
                    }
                }
                i++;
            }
        }

    }
}
