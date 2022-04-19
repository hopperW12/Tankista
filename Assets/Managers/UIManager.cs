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

    public GameObject SpawnUI(int arrayIndex, GameObject obj)
    {
        Instantiate(uis[arrayIndex],GameObject.Find("Canvas").transform);
        return obj;
    }

    public void NextLevelButton()
    {
        GameInstance.Instance.Player.canMove = true;
    }
}
