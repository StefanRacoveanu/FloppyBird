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
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _gameOverText;
    private SpawnManager _spawnManager;
    private CameraScript _cameraScript;
    private GameObject _player;

    private void Start()
    {
        InitialiseVariables();
    }

    private void InitialiseVariables()
    {
        _text = GameObject.Find("Score").GetComponent<Text>();
        if (_text == null)
            Debug.LogError("_text is NULL!");
        
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
            Debug.LogError("_spawnManager is NULL!");

        _player = GameObject.Find("Player");
        if (_player == null)
            Debug.LogError("_player is NULL!");
        
        _cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        if (_cameraScript == null)
            Debug.LogError("_cameraScript is NULL!");
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

    IEnumerator FlashGameOverText()
    {
        while (true)
        {
            _gameOverText.SetActive(!_gameOverText.activeSelf);
            yield return new WaitForSeconds(0.75f);
        }
    }

    public void OnDeath()
    {
        _spawnManager.StopSpawn();
        StartCoroutine(FlashGameOverText());
        Destroy(_cameraScript);
        Destroy(_player);
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
