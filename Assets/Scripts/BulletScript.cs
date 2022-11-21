using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    public float _speed;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _direction * _speed;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
