using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject[] uis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnUI(int arrayIndex)
    {
        
    }

    public void NextLevelButton()
    {
        GameInstance.Instance.Player.canMove = true;
    }
}
