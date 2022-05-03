using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float fov = 90f;

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

        Vector3 direction = -transform.parent.transform.forward;
        setDirection(direction);

        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 4f;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int triangleIndex = 0;
        int vertexIndex = 1;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            /*
            RaycastHit2D raycast = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);
            if (raycast.collider == null) 
                vertex = origin + GetVectorFromAngle(angle) * viewDistance; 
            else 
                vertex = raycast.point;
            */

            vertex = origin + GetVectorFromAngle(angle) * viewDistance; 
            
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
