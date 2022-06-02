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

    //Po vytvoreni hrace
    private void Awake()
    {
        GameInstance.Instance.Player = GetComponentInChildren<Player>(); //Nastaveni do GameInstance
        GameInstance.Instance.UIManager.Show("player"); //Rozbrazeni UI
    }

    //Funkce se vola kazdy snimek
    void FixedUpdate()
    {
        //Pokud se muze hybat tak vezni smer + rychlost a čas a zjistit okolik ho mas za snimek posunout
        if (canMove)
        {
            /*
                KeyCode.... = klavesa
            */
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

    //Funkce ktera se vola pri stretnuti s AI
    public void AITrigger(GameObject gameObject, SoldierInfo soldierInfo)
    {
        if (gameObject.name != name) return;
        if (isDead) return;

        isDead = true; 
        GameInstance.Instance.UIManager.Show("respawn");
        GameInstance.Instance.PauseGame(); 
    }

    //Funkce na respawn hrace
    public void Respawn()
    {
        GameInstance.Instance.ResumeGame(); 
        GameInstance.Instance.LevelManager.DestroyLevel(); 
        GameInstance.Instance.LevelManager.SpawnLevel();

        GameInstance.Instance.UIManager.Hide();
        GameInstance.Instance.UIManager.Show("player");
    }
}
