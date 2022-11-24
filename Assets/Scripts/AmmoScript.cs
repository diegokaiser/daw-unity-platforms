using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public AudioClip _audioclip;
    private Animator _animator;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void GetAmmo()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement _playerMovement = collision.collider.GetComponent<PlayerMovement>();
        if (_playerMovement != null)
        {
            _playerMovement.Ammo();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioclip);
            GetAmmo();
        }
    }
}
