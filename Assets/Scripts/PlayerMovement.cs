using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    public List<Vector3> _originPoints;
    public GameObject _bulletPrefab;
    private float _horizontal;
    private float _lastShoot;
    public float _jumpForce;
    public float _speed;
    public bool _grounded;
    public float _length = 0.575f;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (_horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        } else if (_horizontal > 0.0f) {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        _animator.SetBool("Running", _horizontal != 0.0f);
        for (int i = 0; i < _originPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + _originPoints[i], Vector3.down * _length, Color.red);
            RaycastHit2D _hit = Physics2D.Raycast(transform.position + _originPoints[i], Vector3.down, _length);
            if (_hit)
            {
                Debug.DrawRay(transform.position + _originPoints[i], Vector3.down * _hit.distance, Color.green);
                _grounded = true;
            } else
            {
                _grounded = false;
            }
        }        
        if (Input.GetKey(KeyCode.W) && _grounded)
        {
            Jump();
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse1)) && Time.time > _lastShoot + 0.25f)
        {
            Shoot();
            _lastShoot = Time.time;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    private void Shoot()
    {
        Vector3 _direction;
        if (transform.localScale.x == 1.0f)
        {
            _direction = Vector2.right;
        } else
        {
            _direction = Vector2.left;
        }
        GameObject _bullet = Instantiate(_bulletPrefab, transform.position + _direction * 0.1f, Quaternion.identity);
        _bullet.GetComponent<BulletScript>().SetDirection(_direction);
    }
}
