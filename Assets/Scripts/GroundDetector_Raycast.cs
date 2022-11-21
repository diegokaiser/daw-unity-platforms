using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector_Raycast : MonoBehaviour
{
    Animator _animator;
    public bool _grounded;
    public float _length = 1;
    public LayerMask _mask;
    public List<Vector3> _originPoints;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _grounded = false;
        for (int i = 0; i < _originPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + _originPoints[i], Vector3.down * _length, Color.red);
            RaycastHit2D _hit = Physics2D.Raycast(transform.position + _originPoints[i], Vector3.down, _length, _mask);
            if (_hit.collider != null)
            {
                Debug.DrawRay(transform.position + _originPoints[i], Vector3.down * _hit.distance, Color.green);
                _grounded = true;
            }
        }
    }
}
