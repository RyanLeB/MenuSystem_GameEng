using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager _uiManager;
    public LevelManager _levelManager;

    public GameObject player;


    public enum GameState { MainMenu, Gameplay, Paused, Options, GameWin, GameOver }
    public GameState gameState;

    public void Awake()
    {
        
        Cursor.visible = true;
        gameState = GameState.MainMenu;

        player.SetActive(false);

        _levelManager = FindObjectOfType<LevelManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }


    private void Update()
    {
        
        // Pause game 
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gameState == GameState.Gameplay) 
            {
                Paused();
            }
            else
            {
                ResumeGame();
            }
        }
        
        switch (gameState)
        {
            case GameState.MainMenu: MainMenu(); 
                break;
            case GameState.Gameplay: Gameplay(); 
                break;
            case GameState.Paused: Paused();
                break;
            case GameState.Options: Options();
                break;
            case GameState.GameWin: GameWin();
                break;
            case GameState.GameOver: GameOver();
                break;

        }

        


    }

    public void SetGameStateFromScene(string sceneName)
    {
        switch (sceneName)
        {
            case "MainMenu":
                gameState = GameState.MainMenu;
                break;
            case "Grass_LVL":
                gameState = GameState.Gameplay;
                break;
            case "Grass_LVL2":
                gameState = GameState.Gameplay;
                break;
            
            

            default:
                Debug.LogWarning("SetGameStateFromScene: Unknown scene name - " + sceneName);
                break;
        }
    }

    private void MainMenu()
    {
        _uiManager.UIMainMenu();
        player.SetActive(false);
    }

    private void Gameplay()
    {
        _uiManager.UIGameplay();
        Cursor.visible = false;
        player.SetActive(true);
        
        
    }

    private void Paused()
    {
        _uiManager.UIpause();
        Time.timeScale = 0f;
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Gameplay();
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        gameState = GameState.Gameplay;
    }

    private void Options()
    {
        gameState = GameState.Options;
        _uiManager.UIoptions();

    }

    private void GameWin()
    {
        gameState = GameState.GameWin;
        _uiManager.UIGameWin();
        Cursor.visible = true;
        
    }
    private void GameOver()
    {
        gameState = GameState.GameOver;
        _uiManager.UIGameOver();
        Cursor.visible = true;
    }

}
