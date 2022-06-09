using UnityEngine;

public class Bush : MonoBehaviour
{
    //Pokud je kolidovaný objekt hráč
    //Použití knihovny LeanTween pro plynulý přechod
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 0.5f, 0.5f);
        }
    }

    //Pokud je kolidovaný objekt hráč
    //Použití knihovny LeanTween pro plynulý přechod
    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.name == "Player")
        {
            LeanTween.alpha(this.gameObject, 1f, 0.5f);
        }
    }
}
