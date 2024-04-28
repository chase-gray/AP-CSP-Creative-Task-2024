using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Changes to game scene
    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Changes to title scene
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    // Restarts current scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}