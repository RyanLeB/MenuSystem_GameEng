using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager _uiManager;
    public LevelManager _levelManager;
    
    public enum GameState { MainMenu, Gameplay, Paused, Options, GameWin, GameOver }
    public GameState gameState;

    public void Awake()
    {
        
        Cursor.visible = true;
        gameState = GameState.MainMenu;

        _levelManager = FindObjectOfType<LevelManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }


    private void Update()
    {
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

    private void MainMenu()
    {
        _uiManager.UIMainMenu();
    }

    private void Gameplay()
    {
        _uiManager.UIGameplay();
    }

    private void Paused()
    {
        _uiManager.UIpause();
    }

    private void Options()
    {
        _uiManager.UIoptions();
    }

    private void GameWin()
    {
        _uiManager.UIGameWin();
    }
    private void GameOver()
    {
        _uiManager.UIGameOver();
    }

}
