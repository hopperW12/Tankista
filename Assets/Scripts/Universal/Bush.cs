using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    //Pokud je kolidovan� objekt hr��
    //Pou�it� knihovny LeanTween pro plynul� p�echod
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 0.5f, 0.5f);
        }
    }

    //Pokud je kolidovan� objekt hr��
    //Pou�it� knihovny LeanTween pro plynul� p�echod
    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 1f, 0.5f);
        }
    }
}
