using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    private int _score;
    private Text _text;

    private void Start()
    {
        InitialiseVariables();
    }

    private void InitialiseVariables()
    {
        _text = GameObject.Find("Score").GetComponent<Text>();
    }

    public void UpdateScore(int score)
    {
        _score = score;
        
    }

    private void UpdateScoreOnScreen()
    {
        
    }
}
