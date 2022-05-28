using System.Collections;
using System.Collections.Generic;
using AI;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 10f;
    public bool canMove = true;
    private void Awake()
    {
        GameInstance.Instance.Player = GetComponentInChildren<Player>();
        GameInstance.Instance.UIManager.Show("player");
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
        if (isDead) return;

        isDead = true;
        GameInstance.Instance.UIManager.Show("respawn");
        GameInstance.Instance.PauseGame();
    }

    public void Respawn()
    {
        GameInstance.Instance.ResumeGame();
        GameInstance.Instance.LevelManager.DestroyLevel();
        GameInstance.Instance.LevelManager.SpawnLevel();

        GameInstance.Instance.UIManager.Hide();
        GameInstance.Instance.UIManager.Show("player");
    }
}
