using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "player")
        {

        }
        Destroy(collider.gameObject);

    }
}
