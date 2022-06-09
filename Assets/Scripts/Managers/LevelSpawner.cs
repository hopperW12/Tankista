using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameInstance.Instance.LevelManager.SpawnLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
