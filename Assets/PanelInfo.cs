using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
    private GameObject[] players;

    public Text[] playerTexts = new Text[4];
    public Image[] playerImages = new Image[4];
    
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void findPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update ()
    {
        for(int i = 0; i < players.Length; i++)
        {
            playerTexts[i].text = "Damage: " + players[i].GetComponent<Damage>().getDamageMul()
               + "\nDeaths: " + players[i].GetComponent<Damage>().getTimesDied();
            playerImages[i].sprite = players[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
