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
        //Vytvoření celého levelu
        //[activeLevel] se zamění za číslici levelu, který je vybrán v menu
        levelObj = Instantiate(levels[activeLevel].levelPrefab);
        
        //Script uloží hráče a samotný spawnpoint do proměnné
        spawnpoint = GameObject.Find("SPAWNPOINT");
        player = GameObject.Find("Player");
        GameInstance.Instance.Player.canMove = true;
        GameInstance.Instance.Player.isDead = false;

        //Hráčova pozice se ještě před začátkem hry nastaví na spawnpoint, který je již předem umístěný v každém levelu
        player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, player.transform.position.z);
    }

    //Level se zničí
    //Normálně by byla použita funkce Destroy(levelObj)
    //Jelikož potřebujeme objekt zničit hned po vyvolání funkce, je zde použita funkce DestroyImmediate()
    public void DestroyLevel()
    {
        DestroyImmediate(levelObj);
    }

    //Při dokončení levelu se hráči k proměnné ve které se ukládá level přičte jedno číslo
    //Starý level se odstraní a jelikož se k proměnné přičetlo jedno číslo, spawne se level nový
    //Nakonec se odstraní UI
    public void NextLevel()
    {
        activeLevel++;
        DestroyLevel();
        SpawnLevel();
        Destroy(endLevelUIobj);
    }
}
