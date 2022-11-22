using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public List<Transform> _points;
    int _actualPoint;
    public float _speed;

    void Start()
    {
        transform.position = _points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _points[_actualPoint].position) < 0.1f)
        {
            _actualPoint++;
            if(_actualPoint >= _points.Count)
            {
                _actualPoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, _points[_actualPoint].position, _speed * Time.deltaTime);
    }
}
