using AI;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    //Nastaveni skriptu
    [System.Serializable]
    public class AITriggerEvent : UnityEvent<GameObject,SoldierInfo> {}
    
    public AITriggerEvent AITrigger = new AITriggerEvent();
    
    public LayerMask ignore; //Masky ktere se maji ignorovat pri vytvareno trojuhelniku
    public float fov = 90f;
    public float viewDistance = 4f;

    private Mesh _mesh;
    private float _startingAngle;

    //Funkce se vola pri vytvoreni 
    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        _startingAngle = 90;
    }

    //Funkce se kona pri kazdem vykreslenem snimku
    void Update() {
        Vector3 origin = new Vector3(0, 0, 0);
        //Nastaveni smeru
        Vector3 direction = -transform.parent.transform.up;
        setDirection(direction);

        int rayCount = 50; //Pocet trojuhelniku
        float angle = _startingAngle - 90; //-90 Protoze UNITY ma jinou jednotkovou kruznici.
        float angleIncrease = fov / rayCount;  

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3]; 

        vertices[0] = origin;

        int triangleIndex = 0;
        int vertexIndex = 1;
        
        //Vykreslovani trojuhelniku
        for (int i = 0; i <= rayCount; i++) {
            //Fix = No kdyz se nahodou stane ze AI uz neexistuje tak aby se to ukončilo
            if (this == null) return; 

            Vector3 vertex;
            //Raycast - caru, kterou strilim aby se vykresil trojuhelnik
            RaycastHit2D raycast = Physics2D.Raycast(transform.TransformPoint(origin), GetVectorFromAngle(angle), viewDistance, ~ignore);
            //Kdyz trojuhelnik nic nehitne tak jeho delka bude podle promenne viewDistance
            if (raycast.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle - _startingAngle - 90 - fov / 2) * viewDistance;
            }
            //Pokud raycast nic nehitne tak delka toho raycastu bude po hitnutej objekt
            else
            {
                var gameObject = raycast.transform.gameObject;
                AITrigger.Invoke(gameObject, GetComponentInParent<AIController>().soldierInfo);
                vertex = origin + GetVectorFromAngle(angle - _startingAngle - 90 - fov / 2) * raycast.distance;
            }

            vertices[vertexIndex] = vertex;
            
            //Vytvoreni samotneho trojuhelniku
            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease; //Zmena uhlu vystrelu
        }
        
        _mesh.vertices = vertices;   
        _mesh.uv = uv;  
        _mesh.triangles = triangles;
    }
    
    //Nastaveni smeru FOV
    public void setDirection(Vector3 direction) {
        _startingAngle = GetAngleFromVectorFloat(direction) - fov / 2f;
    }

    //Ziskani uhlu z vektoru
    public float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    //Ziskani vektoru z uhlu
    public Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0);
    }
}
