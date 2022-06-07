﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funkce OnTriggerEnter2D se vyvolá když s něčím bude objekt, který má na sobě tento script kolidovat
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Pokud je kolidovaný objekt hráč, vyvolá se UI pro konec levelu
        if(other.name == "Player")
        {
            //Zamezení pohybu hráči
            GameInstance.Instance.Player.canMove = false;
            //Zavolání na vlastní funkci Show
            GameInstance.Instance.UIManager.Show("nextlevel");
        }
    }
}
