using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _teavaPrefab;
    [SerializeField] private float _distance;
    
    private float _lastTeava = 0.0f;
    private float _nextPos = 0f;
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialiseVariables();
        Spawn3Teava();
        
    }

    private void Spawn3Teava()
    {
        for (int i = 0; i < 3; i++)
        {
            SpwanTeava();
        }
    }

    private void SpwanTeava()
    {
        //float _playerPos = _player.transform.position.x;
        float nextTeavaPos = _lastTeava + _distance;
        Instantiate(_teavaPrefab, new Vector3(nextTeavaPos, Random.Range(3.6f, -3.6f), 0f),
            Quaternion.identity);
        _lastTeava = nextTeavaPos;
        //_nextPos = _playerPos + 5f;
    }

    private void CheckForSpawn()
    {
        float _playerPos = _player.transform.position.x;
        if (_playerPos >= _nextPos)
        {
            SpwanTeava();
            _nextPos += _distance;
        }
    }

    private void InitialiseVariables()
    {
        _player = GameObject.Find("Player");
        if (_player == null)
            Debug.LogError("_player is NULL!");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSpawn();
    }
}
