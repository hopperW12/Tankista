using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 5f;

    public List<Vector2> points;
    void Start()
    {
        transform.LookAt(points[0]);
    }

    private void FixedUpdate() {
        transform.position += Vector3.up * speed * Time.fixedTimeDelta;
    }

}
