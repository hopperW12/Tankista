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
        //For pøeète každý level a vytvoøí pro nìj tlaèítko na start
        foreach (Level level in GameInstance.Instance.LevelManager.levels)
        {
            //Spawnutí pøedem nadefinovaného tlaèítka
            GameObject button = Instantiate(levelButtonObj, gameObject.transform);
            //Nastavení textu tlaèítka na èíslo levelu
            button.GetComponentInChildren<TextMeshProUGUI>().text = level.name;

            //Vytvoøení funkce pro tlaèítko po kliknutí
            void TaskOnClick()
            {
                GameInstance.Instance.LevelManager.activeLevel = int.Parse(level.name) - 1;
                SceneManager.LoadScene("Game");
            }

            //Pøidání funkce TaskOnClick() na tlaèítko
            button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        }
    }
}
