using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    public AudioClip _audioclip;
    public float _speed;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioclip);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement _playerMovement = collision.GetComponent<PlayerMovement>();
        GruntScript _gruntScript = collision.GetComponent<GruntScript>();
        if (_playerMovement != null)
        {
            _playerMovement.Hit();
        }
        DestroyBullet();
    }
}
