using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour {

    public Selection[] select;

    [System.Serializable]
    public struct Selection
    {
        public string playerName;
        public int playerID;
        public Button button;
        public int unlocked; //SE O VALOR FOR 0, O PLAYER NÃO ESTÁ LIBERADO, CASO FOR 1 O PLAYER VAI ESTÁ LIBERADO.
        public GameObject cadeado;
        public int playerPrice;
    }

    private void Start()
    {
        for (int i = 0; i < select.Length; i++)
        {

            if (PlayerPrefs.HasKey("Unlocked" + select[i].playerName))
            {
                select[i].unlocked = PlayerPrefs.GetInt("Unlocked" + select[i].playerName, select[i].unlocked);
            }

            if (select[i].unlocked == 0)
            {
                select[i].button.interactable = false;
                select[i].cadeado.SetActive(true);
            }
            else if (select[i].unlocked == 1)
            {
                select[i].button.interactable = true;
                select[i].cadeado.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            GameController.Instance.PlusCoins(1);
            GameController.Instance.UpdateCoinsText();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameController.Instance.MinusCoins(1);
            GameController.Instance.UpdateCoinsText();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SelectPlayer(int id)
    {
        for (int i = 0; i < select.Length; i++)
        {
            if (select[i].unlocked == 1)
            {

                GameController.Instance.playerID = id;
            }
        }
    }
       
    public void UnlockPlayer(string id)
    {
        for (int i = 0; i < select.Length; i++)
        {
            if(select[i].unlocked == 0 && select[i].playerPrice <= GameController.Instance.coins && select[i].playerName == id)
            {
                select[i].unlocked = 1;
                select[i].button.interactable = true;
                select[i].cadeado.SetActive(false);
                GameController.Instance.coins -= select[i].playerPrice;
                GameController.Instance.UpdateCoinsText();
                PlayerPrefs.SetInt("Unlocked" + select[i].playerName, select[i].unlocked);
                PlayerPrefs.SetInt("Coins", GameController.Instance.coins);
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Game_01");
    }
}
