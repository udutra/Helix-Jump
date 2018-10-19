using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int level;
    public Text texto;
    public Image cadeado;
    private string levelString;

    private void Start()
    {
        if(ButtonsSettings.releasedLevelStatic >= level)
        {
            LevelUnlocked();
        }
        else
        {
            LevelLocked();
        }
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            LevelUnlocked();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            LevelLocked();
        }*/
    }

    private void LevelLocked()
    {
        GetComponent<Button>().interactable = false;
        texto.enabled = false;
        cadeado.enabled = true;
    }

    private void LevelUnlocked()
    {
        GetComponent<Button>().interactable = true;
        texto.enabled = true;
        cadeado.enabled = false;
    }

    public void LevelSelect(string level)
    {
        levelString = level;
        SceneManager.LoadScene(levelString);
    }
}
