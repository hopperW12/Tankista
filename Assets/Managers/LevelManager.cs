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

    void Start()
    {
        
    }

    public void SpawnLevel()
    {

        levelObj = Instantiate(levels[activeLevel].levelPrefab);

        spawnpoint = GameObject.Find("SPAWNPOINT");
        tank = GameObject.Find("Tank");
        player = GameObject.Find("Player");

        player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, player.transform.position.z);

        //Setting compass target on tank
        player.GetComponentInChildren<Compass>().target = tank;
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
