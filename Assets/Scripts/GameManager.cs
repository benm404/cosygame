using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int coins = 0;
    public TextMeshProUGUI Coins;

    void Start()
    {
        Coins.text = "Coins: " + coins;
    }

    
    void Update()
    {
        Coins.text = "Coins: " + coins;
    }
}
