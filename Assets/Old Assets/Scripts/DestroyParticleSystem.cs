﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{ 
    [SerializeField]
    private float duration;
    [SerializeField]
    private float scaleFactor;

    private GameManager _gm;
    private bool scaled = false;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        Debug.Log("WallEffect Forward: " + this.transform.forward);
    }

    private void Update()
    {
        if (_gm == null)
        {
            _gm = FindObjectOfType<GameManager>();
        }
        else if (scaled == false)
        {
            Vector3 scaleVector = new Vector3(_gm.GetGameWorldScale(), _gm.GetGameWorldScale(), _gm.GetGameWorldScale()) * scaleFactor;
            this.transform.localScale = scaleVector;
            Invoke("DiE", duration);
            scaled = true;
        }
    }


    private void DiE()
    {
        Destroy(this.gameObject);
    }
}
