using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _bulletPrefab;
    private float _lastShoot;

    private void Update()
    {
        if (_player == null)
        {
            return;
        }

        Vector3 _direction = _player.transform.position - transform.position;
        if (_direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        } else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        float _distance = Mathf.Abs(_player.transform.position.x - transform.position.x);
        if (_distance < 5.0f && Time.time > _lastShoot + 0.7f)
        {
            Shoot();
            _lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 _direction;
        if (transform.localScale.x == 1.0f)
        {
            _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.left;
        }
        GameObject _bullet = Instantiate(_bulletPrefab, transform.position + _direction * .7f, Quaternion.identity);
        _bullet.GetComponent<BulletScript>().SetDirection(_direction);
    }
}
