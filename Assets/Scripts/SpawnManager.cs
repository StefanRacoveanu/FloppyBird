using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _teavaPrefab;
    [SerializeField] private float _distance;
    
    private float _lastPipe = 0.0f;
    private GameObject _player;
    private Transform _pipeContainer;
    private Coroutine _pipeSpawner;
    private Coroutine _pipeDestroyer;

    // Start is called before the first frame update
    void Start()
    {
        InitialiseVariables();
        Spawn3Pipes();
        _pipeSpawner = StartCoroutine(PipeSpawner());
        _pipeDestroyer = StartCoroutine(PipeDestroyer());
    }

    private void Spawn3Pipes()
    {
        for (int i = 0; i < 3; i++)
        {
            SpwanPipe();
        }
    }

    private void SpwanPipe()
    {
        //float _playerPos = _player.transform.position.x;
        float nextPipePos = _lastPipe + _distance;
        GameObject gameObject = Instantiate(_teavaPrefab, new Vector3(nextPipePos, Random.Range(3.6f, -3.6f), 0f),
            Quaternion.identity);
        gameObject.transform.SetParent(_pipeContainer);
        _lastPipe = nextPipePos;
        //_nextPos = _playerPos + 5f;
    }

    public void StopSpawn()
    {
        StopCoroutine(_pipeSpawner);
        StopCoroutine(_pipeDestroyer);
    }

    private IEnumerator PipeSpawner()
    {
        while (true)
        {
            SpwanPipe();
            yield return new WaitForSeconds(2.24f);
        }
    }

    private IEnumerator PipeDestroyer()
    {
        yield return new WaitForSeconds(9f);
        while (true)
        {
            Destroy(_pipeContainer.GetChild(0).gameObject);
            yield return new WaitForSeconds(2.3f);
        }
    }
    
    private void InitialiseVariables()
    {
        _player = GameObject.Find("Player");
        if (_player == null)
            Debug.LogError("_player is NULL!");

        _pipeContainer = GameObject.Find("TeavaContainer").GetComponent<Transform>();
    }
}
