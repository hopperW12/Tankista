using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 0f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 1f, 0.5f);
        }
    }
}
