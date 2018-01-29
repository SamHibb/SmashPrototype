using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private int damageMultiplier;

	// Use this for initialization
	void Start () {
        damageMultiplier = 1;
	}
	
	// Update is called once per frame
	public void increaseDamageMul (int multiplier) {

        damageMultiplier += multiplier;
        Debug.Log("multiplier " + damageMultiplier);

    }

    public int getDamageMul()
    {
        return damageMultiplier;
    }

    public void resetDamageMul()
    {
        damageMultiplier = 1;
    }
}
