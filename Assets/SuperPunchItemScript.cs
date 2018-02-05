using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPunchItemScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<Attack>().ChangeStrength(1000);
        Destroy(gameObject);
    }
}
