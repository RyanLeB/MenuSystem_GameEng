using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    
    public GameManager gameManager;
    public void SceneLoad(string levelName)
    {
        SceneManager.LoadScene(levelName);

        gameManager.SetGameStateFromScene(levelName);
    }
}
