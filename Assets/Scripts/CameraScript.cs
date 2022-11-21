using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject _player;

    void Update()
    {
        if (_player == null)
        {
            return;
        }

        Vector3 _position = transform.position;
        _position.x = _player.transform.position.x;
        transform.position = _position;
    }
}
