using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    private int _score;
    private Text _text;
    private bool _
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        InitialiseVariables();
    }

    private void InitialiseVariables()
    {
        _text = GameObject.Find("Score").GetComponent<Text>();
        if (_text == null)
            Debug.LogError("_text is NULL!");
    }

    public void UpdateScore(int score)
    {
        _score = score;
        UpdateScoreOnScreen();
    }

    private void UpdateScoreOnScreen()
    {
        _text.text = "Score: " + _score;
    }

    public void PauseButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _menu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            _menu.SetActive(true);
        }
    }
}
