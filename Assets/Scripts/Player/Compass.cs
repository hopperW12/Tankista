using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{

    public bool enable = true;
    public float compassRotationSpeed = 100f;

    public GameObject target;
    public GameObject hand;

    void Start()
    {
        
    }

    void Update()
    {
        if (!enable)
            return;


        Vector3 handPosition = hand.transform.position;
        Vector3 target = GameObject.Find("Tank").transform.position;

        Quaternion requiredRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(target.x, target.y, handPosition.z) - handPosition);
        hand.transform.rotation = Quaternion.RotateTowards(hand.transform.rotation, requiredRotation, compassRotationSpeed * Time.deltaTime);
        
    }
}
