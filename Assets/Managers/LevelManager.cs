using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int activeLevel;
  
    public List<Level> levels;

    public GameObject levelObj;

    private GameObject spawnpoint;
    private GameObject tank;
    private GameObject player;

    public GameObject endLevelUI;
    private GameObject endLevelUIobj;

    

    public void SpawnLevel()
    {

        levelObj = Instantiate(levels[activeLevel].levelPrefab);

        spawnpoint = GameObject.Find("SPAWNPOINT");
        tank = GameObject.Find("Tank");
        player = GameObject.Find("Player");
        GameInstance.Instance.Player.canMove = true;

        player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, player.transform.position.z);
    }

    public void DestroyLevel()
    {
        Destroy(levelObj);
    }

    public void NextLevel()
    {
        activeLevel++;
        DestroyLevel();
        SpawnLevel();
        Destroy(endLevelUIobj);
    }
}
