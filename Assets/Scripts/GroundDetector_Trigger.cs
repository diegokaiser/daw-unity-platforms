using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector_Trigger : MonoBehaviour
{
    Animator _animator;
    public bool _grounded;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _grounded = true;
        _animator.SetBool("Jump", false);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _grounded = false;
    }
}
