using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 5f;

    public List<Vector2> points;
    
    private int _nextPosition;
    void Start()
    {
        transform.position = new Vector3(points[0].x, points[0].y, transform.position.z);
    }

    void Update()
    {
        float step = Time.deltaTime * speed;
        Vector2 nextPosition = points[_nextPosition];

        Vector3 direction = new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position;
        transform.up = direction;
        
        
        transform.position = new Vector3(Vector2.MoveTowards(transform.position, nextPosition, step).x,
            Vector2.MoveTowards(transform.position, nextPosition, step).y, transform.position.z);

        if (Vector2.Distance(transform.position, nextPosition) < 0.001f)
            NextPoint();
        }

    void NextPoint()
    {
        _nextPosition++;
        
        if (_nextPosition == points.Count)
            _nextPosition = 0;
    }

    
    
}
