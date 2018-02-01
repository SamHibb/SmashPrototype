using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlayerAmount : MonoBehaviour {

    Button thisButton;
    public int player_amount;

    void Start()
    {
        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnPlayer>().amountOfPLayer(player_amount);
    }
    
}
