/*
Program:    Tankista
Jméno:      Daniel Kuchař a Tomáš Pecka
Třída:      3.B
Zpracování: 8.3 - 10.6
*/

using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance { get; private set; }
    public Player Player { get; set; }
    public LevelManager LevelManager { get; private set; }
    public MenuManager MenuManager { get; private set; }
    public UIManager UIManager { get; private set; }

    // Singleton
    // Objekt který má na sobě skript GameInstance se nikdy nebude nacházet vícekrát ve scéně
    // Pokud už objekt je ve scéně a další se chce spawnout, tak ho to ihned zničí
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        LevelManager = GetComponentInChildren<LevelManager>();
        MenuManager = GetComponentInChildren<MenuManager>();
        UIManager = GetComponentInChildren<UIManager>();
    }

    // Funkce na pauznutí hry
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    // Funkce na obnovení hry
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Funkce na spawnutí dalšího levelu
    public void NextLevel()
    {
        Instance.LevelManager.NextLevel();
        Instance.UIManager.Hide();
    }
}
