using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;


public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3[] _points; 
    [SerializeField] private float _speed;
    [SerializeField] private int _waiting;

    private int _targetIndex;
   
    private void Start()
    {
        GenerateRandomPoints();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        var travelDistance = _speed * Time.deltaTime;
        var newPosition = Vector3.MoveTowards(transform.position, _points[_targetIndex], travelDistance);
        transform.LookAt(_points[_targetIndex]);
        
        transform.position = newPosition;
        
        if (transform.position == _points[_targetIndex])
        {
            Thread.Sleep(_waiting*1000);
            _targetIndex++;
        }
        if (_targetIndex >= _points.Length)
        {
            _targetIndex = 0;
        }
    }
    private void GenerateRandomPoints()
    {
        for (var i = 0; i < _points.Length; i++)
        {
            _points[i] = new Vector3(Random.Range(-3.5f, 3.5f), 0f, Random.Range(-3.5f, 3.5f));
        }
    }
    
}
