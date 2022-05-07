using System;
using System.Collections;
using System.Collections.Generic;
using AI;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class AIMovement : MonoBehaviour
{
    [FormerlySerializedAs("SoldierInfo")]
    [Header("Soldier Info")] 
    public SoldierInfo soldierInfo;
 
    [Header("Base Settings")]
    public float speed = 5f;
    public float rotationSpeed = 45f;

    [Header("FOV Settings")] 
    public LayerMask ignoreMask;
    public float fov = 90;
    public float viewDistance = 4f;
    public Material fovMaterial;
    
    [Header("Path")]
    public List<Vector2> points;
    
    private int _nextPosition;
    private ActionStatus status;
    private bool _activate;


    private void Start()
    {
        if (points.Count > 1) _activate = true;
        else return;
        
        soldierInfo = SoldierInfo.GetRandomSoldier();
        
        //Default start
        _nextPosition++;
        Vector2 nextPosition = points[_nextPosition];

        transform.position = new Vector3(points[0].x, points[0].y, transform.position.z);
        Vector3 direction = new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position;
        transform.up = direction;
        status = ActionStatus.MOVE;
        
        //Field Of View
        GameObject fov = new GameObject("FieldOfView");
        fov.AddComponent<MeshFilter>();
        fov.AddComponent<MeshRenderer>();
        fov.AddComponent<FieldOfView>();
        
        fov.GetComponent<MeshRenderer>().material = fovMaterial;
        
        FieldOfView fieldOfView = fov.GetComponent<FieldOfView>();
        fieldOfView.AITrigger.AddListener(GameInstance.Instance.Player.AITrigger);
        fieldOfView.ignore = ignoreMask;
        fieldOfView.fov = this.fov;
        fieldOfView.viewDistance = this.viewDistance;
        
        fov.transform.SetParent(transform, false);
    }
    

    void Update()
    {
        if (!_activate)
            return;

        //Movement & Rotation    
        Vector2 nextPosition = points[_nextPosition];    

        switch(status) {
            case ActionStatus.MOVE:
                float step = Time.deltaTime * speed;
                transform.position = new Vector3(Vector2.MoveTowards(transform.position, nextPosition, step).x,
                Vector2.MoveTowards(transform.position, nextPosition, step).y, transform.position.z);

                if (Vector2.Distance(transform.position, nextPosition) < 0.001f) {
                     _nextPosition++;
                    if (_nextPosition == points.Count)
                        _nextPosition = 0;

                    status = ActionStatus.ROTATION;
                }
                break;
            case ActionStatus.ROTATION:
                Vector3 direction = new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position;
                Quaternion requiredRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation, rotationSpeed * Time.deltaTime);

                if (requiredRotation == transform.rotation)
                    status = ActionStatus.MOVE;
                break;
        }
    }
       
}



public enum ActionStatus {
    MOVE,
    ROTATION
}