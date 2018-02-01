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

    public Image player1Image;
    public Image player2Image;
    public Image player3Image;
    public Image player4Image;


    public void findPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update ()
    {
        if (players.Length > 0)
        {
            player1Text.text = "Damage: " + players[0].GetComponent<Damage>().getDamageMul()
                + "\nDeaths: " + players[0].GetComponent<Damage>().getTimesDied();
            player1Image.sprite = players[0].GetComponent<SpriteRenderer>().sprite;
        }
        if (players.Length > 1)
        {
            player2Text.text = "Damage: " + players[1].GetComponent<Damage>().getDamageMul()
                 + "\nDeaths: " + players[1].GetComponent<Damage>().getTimesDied();
            player2Image.sprite = players[1].GetComponent<SpriteRenderer>().sprite;
        }
        if (players.Length > 2)
        {
            player3Text.text = "Damage: " + players[2].GetComponent<Damage>().getDamageMul()
                 + "\nDeaths: " + players[2].GetComponent<Damage>().getTimesDied();
            player3Image.sprite = players[2].GetComponent<SpriteRenderer>().sprite;
        }
        if (players.Length > 3)
        {
            player4Text.text = "Damage: " + players[3].GetComponent<Damage>().getDamageMul()
                 + "\nDeaths: " + players[3].GetComponent<Damage>().getTimesDied();
            player4Image.sprite = players[3].GetComponent<SpriteRenderer>().sprite;
        } 
    }
}
