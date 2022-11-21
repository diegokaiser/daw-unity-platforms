using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMoviment : MonoBehaviour
{
    Rigidbody2D _rb;
    GroundDetector_Raycast _ground;
    public float _force = 20;
    public float _forceAir = 12;
    public int _jumps_max = 1;
    int _jumps;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ground = GetComponent<GroundDetector_Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_ground._grounded)
        {
            _jumps = _jumps_max;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && _jumps > 0)
        {
            _jumps--;
            if (_ground._grounded)
            {
                _rb.AddForce(new Vector2(0, _force));
            } else
            {
                _rb.AddForce(new Vector2(0, _forceAir));
            }            
        }
    }
}
