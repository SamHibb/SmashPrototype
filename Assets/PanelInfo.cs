using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
    private GameObject[] players;

    public Text player1Text;
    public Text player2Text;
    public Text player3Text;
    public Text player4Text;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update ()
    {
        if (players.Length > 0)
        {
            player1Text.text = "Damage: " + players[0].GetComponent<Damage>().getDamageMul()
                + "Deaths: " + players[0].GetComponent<Damage>().getTimesDied();
        }
        if (players.Length > 1)
        {
            player2Text.text = "Damage: " + players[1].GetComponent<Damage>().getDamageMul()
                 + "Deaths: " + players[1].GetComponent<Damage>().getTimesDied();
        }
        if (players.Length > 2)
        {
            player3Text.text = "Damage: " + players[2].GetComponent<Damage>().getDamageMul()
                 + "Deaths: " + players[2].GetComponent<Damage>().getTimesDied();
        }
        if (players.Length > 3)
        {
            player4Text.text = "Damage: " + players[3].GetComponent<Damage>().getDamageMul()
                 + "Deaths: " + players[3].GetComponent<Damage>().getTimesDied(); 
        } 
    }
}
