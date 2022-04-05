using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public GameObject levelButtonObj;

    void Start()
    {
        foreach (Level level in GameInstance.Instance.LevelManager.levels)
        {
            GameObject button = Instantiate(levelButtonObj, gameObject.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = level.name;

            void KOKOTINA()
            {
               // Invoke(GameInstance.Instance.MenuManager.LoadLevel(int.Parse(level.name));
            }

            button.GetComponent<Button>().onClick.AddListener(KOKOTINA);
            button.GetComponent<Button>().onClick.Invoke();
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
