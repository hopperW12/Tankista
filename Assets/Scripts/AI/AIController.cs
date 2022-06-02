using System.Collections.Generic;
using AI;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //Zakladni nastaveni AI v editoru
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

    //Funkce se vola pri vytvoreni AI
    private void Start() 
    {
        //Pokud neni nastavena cesta tak zůstan na mistě
        if (points.Count > 1)
            _activate = true;
        else 
            return;
        
        //Vygenerovani informaci o AI
        soldierInfo = SoldierInfo.GetRandomSoldier();
        
        //Nastaveni dalsi pozice a směru divani
        _nextPosition++;
        Vector2 nextPosition = points[_nextPosition];

        transform.position = new Vector3(points[0].x, points[0].y, transform.position.z);
        Vector3 direction = new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position;
        transform.up = direction;
        status = ActionStatus.MOVE;
        
        //Vytvoreni Field Of View
        GameObject fov = new GameObject("FieldOfView");
        //Pridani a nastaveni komponentů
        fov.AddComponent<MeshFilter>();
        fov.AddComponent<MeshRenderer>();
        fov.AddComponent<FieldOfView>();
        
        fov.GetComponent<MeshRenderer>().material = fovMaterial;
        
        //Nastaveni Field Of View  
        FieldOfView fieldOfView = fov.GetComponent<FieldOfView>();
        fieldOfView.AITrigger.AddListener(GameInstance.Instance.Player.AITrigger);
        fieldOfView.ignore = ignoreMask;
        fieldOfView.fov = this.fov;
        fieldOfView.viewDistance = this.viewDistance;
        
        //Pridani Field Of View na AI
        fov.transform.SetParent(transform, false);
    }
    
    //Funkce se kona pri každem vykreslenem snimku
    void Update()
    {
        if (!_activate)
            return;

        //Nastaveni dalsi pozice   
        Vector2 nextPosition = points[_nextPosition];    

        switch(status) {
            //Pohyb v pred
            case ActionStatus.MOVE:
                float step = Time.deltaTime * speed;
                transform.position = new Vector3(Vector2.MoveTowards(transform.position, nextPosition, step).x,
                Vector2.MoveTowards(transform.position, nextPosition, step).y, transform.position.z);

                //Pokud dosahl bodu tak se zacne otacet za dalsim
                if (Vector2.Distance(transform.position, nextPosition) < 0.001f) {
                     _nextPosition++;
                    if (_nextPosition == points.Count)
                        _nextPosition = 0;

                    status = ActionStatus.ROTATION;
                }
                break;
            //Otaceni se za urcitym bodem
            case ActionStatus.ROTATION:

                //Otaceni se za dalsim bodem
                Vector3 direction = new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position;
                Quaternion requiredRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(nextPosition.x, nextPosition.y, transform.position.z) - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation, rotationSpeed * Time.deltaTime);

                //Pokud je ve spravne rotaci prepni se na chozeni
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