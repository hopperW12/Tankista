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
        //Vytvoøení celého levelu
        //[activeLevel] se zamìní za èíslici levelu, který je vybrán v menu
        levelObj = Instantiate(levels[activeLevel].levelPrefab);
        
        //Script uloží hráèe a samotný spawnpoint do promìnné
        spawnpoint = GameObject.Find("SPAWNPOINT");
        player = GameObject.Find("Player");
        GameInstance.Instance.Player.canMove = true;
        GameInstance.Instance.Player.isDead = false;

        //Hráèova pozice se ještì pøed zaèátkem hry nastaví na spawnpoint, který je již pøedem umístìný v každém levelu
        player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, player.transform.position.z);
    }

    //Level se znièí
    //Normálnì by byla použita funkce Destroy(levelObj)
    //Jelikož potøebujeme objekt znièit hned po vyvolání funkce, je zde použita funkce DestroyImmediate()
    public void DestroyLevel()
    {
        DestroyImmediate(levelObj);
    }

    //Pøi dokonèení levelu se hráèi k promìnné ve které se ukládá level pøiète jedno èíslo
    //Starý level se odstraní a jelikož se k promìnné pøièetlo jedno èíslo, spawne se level nový
    //Nakonec se odstraní UI
    public void NextLevel()
    {
        activeLevel++;
        DestroyLevel();
        SpawnLevel();
        Destroy(endLevelUIobj);
    }
}
