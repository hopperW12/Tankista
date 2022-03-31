using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    void Start()
    {
        foreach(Level level in GameInstance.Instance.LevelManager.levels)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
