using System.Collections;
using System.Collections.Generic;
using AI;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public bool canMove = true;


    private GameObject respawnUI;
    private void Awake()
    {
        GameInstance.Instance.Player = GetComponentInChildren<Player>();
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.fixedDeltaTime;
            }
        }
    }

    public void AITrigger(GameObject gameObject, SoldierInfo soldierInfo)
    {
        if (gameObject.name != name) return;

        GameInstance.Instance.PauseGame();
        respawnUI = Instantiate(GameInstance.Instance.UIManager.uis[1], GameObject.Find("Canvas").transform);

        GameInstance.Instance.LevelManager.DestroyLevel();
        GameInstance.Instance.LevelManager.SpawnLevel();
    }

    public void Respawn()
    {
        DestroyImmediate(respawnUI);
        GameInstance.Instance.ResumeGame();
    }
}
