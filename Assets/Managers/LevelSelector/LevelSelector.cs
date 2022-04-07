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
        foreach (Level level in GameInstance.Instance.LevelManager.levels)
        {
            GameObject button = Instantiate(levelButtonObj, gameObject.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = level.name;

            void TaskOnClick()
            {
                GameInstance.Instance.LevelManager.activeLevel = int.Parse(level.name) - 1;
                SceneManager.LoadScene("Game");
            }

            button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
            //button.GetComponent<Button>().onClick.Invoke();
        }
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForLevels()
    {
        
    }
}
