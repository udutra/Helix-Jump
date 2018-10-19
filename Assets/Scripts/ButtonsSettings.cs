﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSettings : MonoBehaviour {

    public static int releasedLevelStatic = 1;
    public int releasedLevel;
    public string nextLevel;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            releasedLevelStatic = PlayerPrefs.GetInt("Level", releasedLevelStatic);
        }
        
    }

    public void ButtonNextLevel()
    {
        Debug.Log("Entroue: " + nextLevel);
        SceneManager.LoadScene(nextLevel);
        if (releasedLevelStatic <= releasedLevel)
        {
            releasedLevelStatic = releasedLevel;
            PlayerPrefs.SetInt("Level", releasedLevelStatic);
        }
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("02_MenuFase");
    }
}
