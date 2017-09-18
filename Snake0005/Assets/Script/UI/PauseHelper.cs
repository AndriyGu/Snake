using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHelper : MonoBehaviour {

    public void PauseGame()
    {
        Time.timeScale = 0.0F;
    } 

    public void ResumeGame()
    { 
        Time.timeScale = 1.0F;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
