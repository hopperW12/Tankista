using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public List<GameObject> levels;
    public GameObject levelButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject level in levels)
        {
            int levelIndex = 0;
            GameObject button = Instantiate(levelButton,gameObject.transform.GetChild(0));
            GameObject textObj = new GameObject("Text");
            GameObject text = Instantiate(textObj, button.transform);
            TextMeshProUGUI TM = text.AddComponent<TextMeshProUGUI>();
            TM.text = levelIndex.ToString();
            levelIndex++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
