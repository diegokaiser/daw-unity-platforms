using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public AudioClip _audioclip;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioclip);
    }

    public void DestroyBomb()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement _playerMovement = collision.GetComponent<PlayerMovement>();
        if (_playerMovement != null)
        {
            _playerMovement.Hit();
        }
        DestroyBomb();
    }
}
