using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private int damageMultiplier = 1;
    private int times_died = 0;
	
	public void increaseDamageMul (int multiplier)
    {
        damageMultiplier += multiplier;
        Debug.Log("multiplier: " + damageMultiplier);

    }

    public int getDamageMul()
    {
        return damageMultiplier;
    }

    public void resetDamageMul()
    {
        damageMultiplier = 1;
    }

    public void increaseTimesDied()
    {
        times_died++;
    }

    public int getTimesDied()
    {
        return times_died;
    }
}
