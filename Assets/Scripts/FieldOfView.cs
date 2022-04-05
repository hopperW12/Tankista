using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;      

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] tringles = new int[rayCount * 3];

        vertices[0] = origin;

        int triangleIndex = 0;
        int vertexIndex = 1;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance; 
            vertices[vertexIndex] = vertex;

            if (i > 0) {
                tringles[triangleIndex + 0] = 0;
                tringles[triangleIndex + 1] = vertexIndex - 1;
                tringles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;   
        mesh.uv = uv;  
        mesh.triangles = tringles;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetVectorFromAngle(float angle) {
        float angleRed = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRed), Mathf.Sin(angleRed));
    }
}
