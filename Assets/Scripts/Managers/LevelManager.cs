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
        //Vytvo�en� cel�ho levelu
        //[activeLevel] se zam�n� za ��slici levelu, kter� je vybr�n v menu
        levelObj = Instantiate(levels[activeLevel].levelPrefab);
        
        //Script ulo�� hr��e a samotn� spawnpoint do prom�nn�
        spawnpoint = GameObject.Find("SPAWNPOINT");
        player = GameObject.Find("Player");
        GameInstance.Instance.Player.canMove = true;
        GameInstance.Instance.Player.isDead = false;

        //Hr��ova pozice se je�t� p�ed za��tkem hry nastav� na spawnpoint, kter� je ji� p�edem um�st�n� v ka�d�m levelu
        player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, player.transform.position.z);
    }

    //Level se zni��
    //Norm�ln� by byla pou�ita funkce Destroy(levelObj)
    //Jeliko� pot�ebujeme objekt zni�it hned po vyvol�n� funkce, je zde pou�ita funkce DestroyImmediate()
    public void DestroyLevel()
    {
        DestroyImmediate(levelObj);
    }

    //P�i dokon�en� levelu se hr��i k prom�nn� ve kter� se ukl�d� level p�i�te jedno ��slo
    //Star� level se odstran� a jeliko� se k prom�nn� p�i�etlo jedno ��slo, spawne se level nov�
    //Nakonec se odstran� UI
    public void NextLevel()
    {
        activeLevel++;
        DestroyLevel();
        SpawnLevel();
        Destroy(endLevelUIobj);
    }
}
