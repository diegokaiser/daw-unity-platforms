using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    public List<Vector3> _originPoints;
    public GameObject _bulletPrefab;
    public GameObject[] _lives;
    public AudioClip _audioStepA, _audioStepB, _audioJump, _audioHurt, _audioDeath, _audioShoot, _audioGameOver;
    public Transform _gameOverPanel, _gameStartPanel, _livesPanel;
    private float _horizontal;
    private float _lastShoot;
    public float _jumpForce;
    public float _speed;
    public bool _grounded;
    public float _length = 0.575f;
    public int _health = 3;
    public bool _canShoot = false;
    public bool _gameStart = false;
    public bool _gameOver = false;

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
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioStepA);

        } else if (_horizontal > 0.0f) {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioStepB);
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
        if (_canShoot)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse1)) && Time.time > _lastShoot + 0.25f)
            {
                Shoot();
                _animator.SetBool("Shooting", true);
                _lastShoot = Time.time;
            }
            else
            {
                _animator.SetBool("Shooting", false);
            }
        }
        if (_gameOver == true)
        {
            Debug.Log("tipos");
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            {
                GameStart();
                Debug.Log("tiene que iniciar");
            }
        }
        if (_gameStart == false)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            {
                GameStart();
                Debug.Log("juego inicia");
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioJump);
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
        GameObject _bullet = Instantiate(_bulletPrefab, transform.position + _direction * .7f, Quaternion.identity);
        _bullet.GetComponent<BulletScript>().SetDirection(_direction);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioShoot);
    }

    public void Hit()
    {
        _health = _health - 1;
        if (_health < 1)
        {
            Destroy(_lives[0].gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioDeath);
            Destroy(gameObject);
            GameOver();
        }
        else if (_health < 2)
        {
            Destroy(_lives[1].gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioHurt);
        }
        else if (_health < 3)
        {
            Destroy(_lives[2].gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioHurt);
        }
    }

    public void Ammo()
    {
        _canShoot = true;
    }

    public void GameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
        _livesPanel.gameObject.SetActive(false);
        _gameOver = true;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(_audioGameOver);
        Debug.Log("Gameover");
    }

    public void GameStart()
    {
        _gameStartPanel.gameObject.SetActive(false);
        _livesPanel.gameObject.SetActive(true);
        _gameStart = true;
    }

    public void GameStartHard()
    {
        _health = _health - 2;
        _gameStartPanel.gameObject.SetActive(false);
        _livesPanel.gameObject.SetActive(true);
        _gameStart = true;
    }
}
