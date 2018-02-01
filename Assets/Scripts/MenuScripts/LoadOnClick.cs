using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

    public int AOPlayers;

	public void LoadScene(int level)
	{
        Application.LoadLevel(level);
	}

    public void amountOfPLayer(int players)
    {
        AOPlayers = players;
    }

    public void doQuit()
    {
        Application.Quit();
    }
}
