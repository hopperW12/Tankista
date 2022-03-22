using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int activeLevel;
  
    public List<GameObject> levels;

    public GameObject levelObj;

    void Update()
    {
        
    }

    public void SpawnLevel()
    {
        //levelObj = Instantiate(levels.FindIndex(activeLevel));
    }
}
