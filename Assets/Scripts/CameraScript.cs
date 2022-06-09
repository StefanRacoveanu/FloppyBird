using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _player;
    void Start()
    {
        _player = GameObject.Find("Player");
        if (_player == null)
            Debug.LogError("_player is null");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x,0f, -10f);
    }
}