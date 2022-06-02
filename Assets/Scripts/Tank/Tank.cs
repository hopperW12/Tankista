using System.Collections;
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

    //Funkce OnTriggerEnter2D se vyvol� kdy� s n���m bude objekt, kter� m� na sob� tento script kolidovat
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Pokud je kolidovan� objekt hr��, vyvol� se UI pro konec levelu
        if(other.name == "Player")
        {
            //Zamezen� pohybu hr��i
            GameInstance.Instance.Player.canMove = false;
            //Zavol�n� na vlastn� funkci Show
            GameInstance.Instance.UIManager.Show("nextlevel");
        }
    }
}
