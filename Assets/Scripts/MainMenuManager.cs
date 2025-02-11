﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleARCore;
using GoogleARCore.Examples.Common;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private SceneTracker ST;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private AudioSource buttonPressedAudio;

    private void Awake()
    {
        ST = FindObjectOfType<SceneTracker>();
        if (ST != null)
        {
            if (ST.GetUsedEscape() == false)
            {
                ST.SetFastSkipMainMenu(true);
                ST.SetUsedEscape(true);
                SceneManager.LoadScene("FightingScene");
            }
            else
            {
                ST.SetFastSkipMainMenu(false);
            }
        }

    }

    void Update()
    {
        if (ST == null)
        {
            Debug.Log("looking for Scene Tracker");
            ST = FindObjectOfType<SceneTracker>();
        }
        else
        {
            if (ST.GetUsedEscape() == false)
            {
                ST.SetFastSkipMainMenu(true);
                ST.SetUsedEscape(true);
                SceneManager.LoadScene("FightingScene");
            }
            else
            {
                ST.SetFastSkipMainMenu(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void StartGame()
    {
        ST.SetFastSkipMainMenu(false);
        buttonPressedAudio.Play();
        startButton.interactable = false;
        Invoke("DelayStartGame", .8f);
    }

    public void DelayStartGame()
    {
        SceneManager.LoadScene("FightingScene");
    }
}
