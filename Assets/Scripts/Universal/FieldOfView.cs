using System.Collections;
using System.Collections.Generic;
using AI;
using UnityEngine;
using UnityEngine.Events;
public class FieldOfView : MonoBehaviour
{
    [System.Serializable]
    public class AITriggerEvent : UnityEvent<GameObject,SoldierInfo> {}
    
    public AITriggerEvent AITrigger = new AITriggerEvent();
    
    public LayerMask ignore;
    public float fov = 90f;
    public float viewDistance = 4f;

    private Mesh _mesh;
    private float _startingAngle;
    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        _startingAngle = 90;
    }

    void Update() {
        Vector3 origin = new Vector3(0, 0, 0);
        Vector3 direction = -transform.parent.transform.up;
        setDirection(direction);

        int rayCount = 50;
        float angle = _startingAngle - 90;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int triangleIndex = 0;
        int vertexIndex = 1;
        for (int i = 0; i <= rayCount; i++) {
            if (this == null) return;

            Vector3 vertex;
            RaycastHit2D raycast = Physics2D.Raycast(transform.TransformPoint(origin), GetVectorFromAngle(angle), viewDistance, ~ignore);
            if (raycast.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle - _startingAngle - 90 - fov / 2) * viewDistance;
            }
            else
            {
                var gameObject = raycast.transform.gameObject;
                AITrigger.Invoke(gameObject, GetComponentInParent<AIMovement>().soldierInfo);
                vertex = origin + GetVectorFromAngle(angle - _startingAngle - 90 - fov / 2) * raycast.distance;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }
        
        _mesh.vertices = vertices;   
        _mesh.uv = uv;  
        _mesh.triangles = triangles;
    }

    public void setDirection(Vector3 direction) {
        _startingAngle = GetAngleFromVectorFloat(direction) - fov / 2f;
    }

    public float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    public Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0);
    }
}
