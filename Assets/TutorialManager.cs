﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject waypoint;
    [SerializeField]
    private GameObject dummy;
    private bool dummySpawned = false;
    [SerializeField]
    private int tutorialStep = 0;

    [SerializeField]
    private Text _waypointText;
    [SerializeField]
    private Text _dummyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((tutorialStep == 1) && (dummySpawned == false))
        {
            dummy.SetActive(true);
            _dummyText.enabled = true;
            dummySpawned = true;
        }
    }

    public void incrementTutorialStep()
    {
        tutorialStep++;
    }
}