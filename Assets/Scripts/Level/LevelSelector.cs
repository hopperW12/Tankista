using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelSelector : MonoBehaviour
{

    public GameObject levelButtonObj;

    void Start()
    {
        //For p�e�te ka�d� level a vytvo�� pro n�j tla��tko na start
        foreach (Level level in GameInstance.Instance.LevelManager.levels)
        {
            //Spawnut� p�edem nadefinovan�ho tla��tka
            GameObject button = Instantiate(levelButtonObj, gameObject.transform);
            //Nastaven� textu tla��tka na ��slo levelu
            button.GetComponentInChildren<TextMeshProUGUI>().text = level.name;

            //Vytvo�en� funkce pro tla��tko po kliknut�
            void TaskOnClick()
            {
                GameInstance.Instance.LevelManager.activeLevel = int.Parse(level.name) - 1;
                SceneManager.LoadScene("Game");
            }

            //P�id�n� funkce TaskOnClick() na tla��tko
            button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        }
    }
}
