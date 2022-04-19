using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    GameObject endUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            GameInstance.Instance.Player.canMove = false;

            void TaskOnClick()
            {
                GameInstance.Instance.LevelManager.NextLevel();
            }
            //TODO: DODELAT NEVIM VOLE JAK ALE
            GameInstance.Instance.UIManager.SpawnUI(0, endUI).GetComponentInChildren<Button>().onClick.AddListener(TaskOnClick);
        }
    }
}
