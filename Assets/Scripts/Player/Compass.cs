using UnityEngine;

public class Compass : MonoBehaviour
{

    public bool enable = true;
    public float compassRotationSpeed = 100f;

    public GameObject target;
    public GameObject hand;

    void Update()
    {
        if (!enable)
            return;

        //Zjisteni pozice hrace a tanku
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3 targetPosition = GameObject.Find("Tank").transform.position;

        //Vypočet smeru za pomocí kvaternionu (získá rotaci)
        Quaternion requiredRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(targetPosition.x, targetPosition.y, playerPosition.z) - playerPosition);
        hand.transform.rotation = Quaternion.RotateTowards(hand.transform.rotation, requiredRotation, compassRotationSpeed * Time.deltaTime);
        
    }
}
