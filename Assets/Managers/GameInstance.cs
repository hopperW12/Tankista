using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance { get; private set; }
    public Player Player { get; set; }
    public LevelManager LevelManager { get; private set; }
    public MenuManager MenuManager { get; private set; }
    public UIManager UIManager { get; private set; }
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

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
