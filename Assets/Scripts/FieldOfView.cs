using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public LayerMask ignore;
    public float fov = 90f;
    public float viewDistance = 4f;

    private Mesh mesh;
    private float startingAngle;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        startingAngle = 90;

    }

    void Update() {
        Vector3 origin = new Vector3(0, 0, 0);

        Vector3 direction = -transform.parent.transform.up;
        setDirection(direction);

        int rayCount = 50;
        float angle = startingAngle - 90;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int triangleIndex = 0;
        int vertexIndex = 1;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            
            
            RaycastHit2D raycast = Physics2D.Raycast(transform.TransformPoint(origin), GetVectorFromAngle(angle), viewDistance, ~ignore);
            if (raycast.collider == null)
                vertex = origin + GetVectorFromAngle(angle - startingAngle - 90 - fov / 2) * viewDistance;
            else
                vertex = origin + GetVectorFromAngle(angle - startingAngle - 90 - fov / 2) * raycast.distance;

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
        
        mesh.vertices = vertices;   
        mesh.uv = uv;  
        mesh.triangles = triangles;
    }

    public void setDirection(Vector3 direction) {
        startingAngle = GetAngleFromVectorFloat(direction) - fov / 2f;
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
