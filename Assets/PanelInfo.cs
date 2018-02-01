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

    public Sprite player1Image;
    public Sprite player2Image;
    public Sprite player3Image;
    public Sprite player4Image;

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
        if (players.Length > 0)
        {
            player1Text.text = "Damage: " + players[0].GetComponent<Damage>().getDamageMul()
                + "\nDeaths: " + players[0].GetComponent<Damage>().getTimesDied();
            player1Image = players[0].GetComponent<Image>().sprite;
        }
        if (players.Length > 1)
        {
            player2Text.text = "Damage: " + players[1].GetComponent<Damage>().getDamageMul()
                 + "\nDeaths: " + players[1].GetComponent<Damage>().getTimesDied();
            player2Image = players[1].GetComponent<Image>().sprite;
        }
        if (players.Length > 2)
        {
            player3Text.text = "Damage: " + players[2].GetComponent<Damage>().getDamageMul()
                 + "\nDeaths: " + players[2].GetComponent<Damage>().getTimesDied();
            player3Image = players[2].GetComponent<Image>().sprite;
        }
        if (players.Length > 3)
        {
            player4Text.text = "Damage: " + players[3].GetComponent<Damage>().getDamageMul()
                 + "\nDeaths: " + players[3].GetComponent<Damage>().getTimesDied();
            player4Image = players[3].GetComponent<Image>().sprite;
        } 
    }
}
