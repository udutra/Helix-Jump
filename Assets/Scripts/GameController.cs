using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int playerID;
    public static GameController Instance;
    public GameObject[] data;
    public int coins;
    public Text coinsText;



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        data = GameObject.FindGameObjectsWithTag("GameController");

        if(data.Length >= 2)
        {
            Destroy(data[1]);
        }
        DontDestroyOnLoad(transform.gameObject);
        coinsText.text = "Coins: " + coins;
    }

    public void PlusCoins(int c)
    {
        if((coins + c) >= 1000)
        {
            coins = 1000;
        }
        else
        {
            coins = coins + c;
        }
    }

    public void MinusCoins(int c)
    {
        if ((coins - c) <= 0)
        {
            coins = 0;
        }
        else
        {
            coins = coins - c;
        }
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + coins;
    }
}
