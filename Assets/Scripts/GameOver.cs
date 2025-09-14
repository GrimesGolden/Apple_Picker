using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        // Load the main game.  
        FindObjectOfType<AudioManager>().Stop("EndTheme");
        FindObjectOfType<AudioManager>().Play("ChanceTheme");
        SceneManager.LoadScene("_Scene_1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT APPLICATION\n");
        // The application won't quit inside of unity editor.
        // Hence the debug log above. 
        Application.Quit(); 
    }
}
