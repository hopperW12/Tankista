using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int activeLevel;
  
    public List<Level> levels;

    public GameObject levelObj;

    public GameObject spawnpoint;
    private GameObject tank;
    private GameObject player;
    
    private GameObject endLevelUIobj;

    

    public void SpawnLevel()
    {

        levelObj = Instantiate(levels[activeLevel].levelPrefab);
        
        spawnpoint = GameObject.Find("SPAWNPOINT");
        player = GameObject.Find("Player");
        GameInstance.Instance.Player.canMove = true;

        player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, player.transform.position.z);
    }

    public void DestroyLevel()
    {
        DestroyImmediate(levelObj);
    }

    public void NextLevel()
    {
        activeLevel++;
        DestroyLevel();
        SpawnLevel();
        Destroy(endLevelUIobj);
    }
}
