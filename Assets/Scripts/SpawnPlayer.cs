using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {
    public GameObject player;
    static int max_players = 2;

    int players_joined = 0;

    string player_no = "P0";

    GameObject[] players = new GameObject[max_players];
	
	void Update ()
    {
		if (Input.GetButtonDown(player_no + "Start"))
        {
            if (players_joined < max_players)
            {
                Debug.Log("spawn player " + players_joined);
                players[players_joined] = Instantiate(player);

                //will hopefully become assign sprite
                assignColour();

                players[players_joined].GetComponent<Movement>().player_no = players_joined;
                players[players_joined].GetComponent<Attack>().player_no = players_joined;

                players_joined++;
                if (players_joined < max_players)
                { 
                player_no = "P" + players_joined;
                }
            }
        }
	}
    
    void assignColour()
    {
        Color colour = Color.white;
        switch (players_joined)
        {
            case 0:
                colour = Color.red;
                break;
            case 1:
                colour = Color.blue;
                break;
            case 2:
                colour = Color.green;
                break;
            case 3:
                colour = Color.yellow;
                break;
            case 4:
                colour = Color.black;
                break;
            case 5:
                colour = Color.white;
                break;
            case 6:
                colour = Color.cyan;
                break;
            case 7:
                colour = Color.magenta;
                break;
            default:
                Debug.Log("colour assignment has gone wrong");
                break;
        }
        players[players_joined].GetComponent<SpriteRenderer>().color = colour;
    }
}
