using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int activeLevel;
  
    public List<GameObject> levels;

    public GameObject levelObj;

    void Start()
    {
        
    }

    public void SpawnLevel()
    {
        levelObj = Instantiate(levels[activeLevel]);
        GameObject.Find("Player").transform.position = GameObject.Find("SPAWNPOINT").transform.position;
    }

    public void DestroyLevel()
    {
        Destroy(levelObj);
    }
}
