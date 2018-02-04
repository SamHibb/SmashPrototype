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


    private void Start()
    {
        player1Text.enabled = false;
        player2Text.enabled = false;
        player3Text.enabled = false;
        player4Text.enabled = false;

        player1Image.enabled = false;
        player2Image.enabled = false;
        player3Image.enabled = false;
        player4Image.enabled = false;
    }

    void Update ()
    {        
        if (players.Length > 0)
        {
            //player1Text.text = "Damage: " + (players[0].GetComponent<Damage>().getDamageMul() * 8) + "%"
            //    + "\nDeaths: " + players[0].GetComponent<Damage>().getTimesDied();
            player1Text.text = (players[0].GetComponent<Damage>().getDamageMul() * 8) + "%\n" + players[0].GetComponent<Damage>().getTimesDied();
            player1Image.sprite = players[0].GetComponent<SpriteRenderer>().sprite;
            player1Text.enabled = true;
            player1Image.enabled = true;
        }
        if (players.Length > 1)
        {
            //player2Text.text = "Damage: " + players[1].GetComponent<Damage>().getDamageMul()
            //     + "\nDeaths: " + players[1].GetComponent<Damage>().getTimesDied();
            player2Text.text = (players[1].GetComponent<Damage>().getDamageMul() * 8) + "%\n" + players[1].GetComponent<Damage>().getTimesDied();
            player2Image.sprite = players[1].GetComponent<SpriteRenderer>().sprite;
            player2Text.enabled = true;
            player2Image.enabled = true;
        }
        if (players.Length > 2)
        {
            //player3Text.text = "Damage: " + players[2].GetComponent<Damage>().getDamageMul()
            //     + "\nDeaths: " + players[2].GetComponent<Damage>().getTimesDied();
            player3Text.text = (players[2].GetComponent<Damage>().getDamageMul() * 8) + "%\n" + players[2].GetComponent<Damage>().getTimesDied();
            player3Image.sprite = players[2].GetComponent<SpriteRenderer>().sprite;
            player3Text.enabled = true;
            player3Image.enabled = true;
        }
        if (players.Length > 3)
        {
            //player4Text.text = "Damage: " + players[3].GetComponent<Damage>().getDamageMul()
            //     + "\nDeaths: " + players[3].GetComponent<Damage>().getTimesDied();
            player4Text.text = (players[3].GetComponent<Damage>().getDamageMul() * 8) + "%\n" + players[3].GetComponent<Damage>().getTimesDied();
            player4Image.sprite = players[3].GetComponent<SpriteRenderer>().sprite;
            player4Text.enabled = true;
            player4Image.enabled = true;
        } 
    }

    public void findPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
