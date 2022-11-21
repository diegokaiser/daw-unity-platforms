using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    GroundDetector_Raycast _ground;
    Animator _animator;
    public float _speed = 14;
    // Start is called before the first frame update
    void Awake()
    {
        _ground = GetComponent<GroundDetector_Raycast>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * _speed, 0);
        _animator.SetBool("Grounded", _ground._grounded);
        _animator.SetBool("Run", horizontal != 0);
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
    }
}
