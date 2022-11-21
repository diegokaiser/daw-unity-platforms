using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject _player;

    private void Update()
    {
        Vector3 _direction = _player.transform.position - transform.position;
        if (_direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        } else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }
}
