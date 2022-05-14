using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
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
            LeanTween.alpha(this.gameObject, 0f, 0.5f);
            Debug.Log("COLLIDE");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 1f, 0.5f);
            Debug.Log("EXIT COLLIDE");
        }
    }
}
