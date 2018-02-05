using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPunchItemScript : MonoBehaviour
{
    public float super_punch_bonus = 40;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Attack>().ChangeStrength(super_punch_bonus);
        Destroy(gameObject);
    }
}
