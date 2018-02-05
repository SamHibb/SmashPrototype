using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Damage>().increaseDamageMul(-10);
        Destroy(gameObject);
    }
}
