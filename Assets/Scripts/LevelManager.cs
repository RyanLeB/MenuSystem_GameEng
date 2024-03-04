using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager GameManager;
    public void SceneLoad(string levelName)
    {
        SceneManager.LoadScene(levelName);
        
    }
}
