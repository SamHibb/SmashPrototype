using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour {
    public GameObject player;
    static int max_players;

    int players_joined = 0;

    string player_no = "P0";

    GameObject[] players;

    public Sprite character1;
    public Sprite character2;
    public Sprite character3;
    public Sprite character4;

    void Start ()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }

	void Update ()
    {
		if (SceneManager.GetActiveScene().name != "Level Selection" && SceneManager.GetActiveScene().name != "Player Select" && SceneManager.GetActiveScene().name != "Game Over")
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
            GameObject.FindGameObjectWithTag("UI").GetComponent<PanelInfo>().findPlayers();
        }
    }


    void assignColour()
    {
        Sprite player_sprites = null;
        switch (players_joined)
        {
            case 0:
                player_sprites = character1;
                break;
            case 1:
                player_sprites = character2;
                break;
            case 2:
                player_sprites = character3;
                break;
            case 3:
                player_sprites = character4;
                break;
            default:
                Debug.Log("sprite assignment has gone wrong");
                break;
        }
        players[players_joined].GetComponent<SpriteRenderer>().sprite = player_sprites;
    }

    public void amountOfPLayer(int n)
    {
        max_players = n;
        players = new GameObject[max_players];
        Debug.Log(n);
    }

}
