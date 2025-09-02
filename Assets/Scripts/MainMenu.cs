using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Simply use scene manager to load the next scene in the build sequence.
        // Note: Scenes must be added to build settings. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT APPLICATION\n");
        // The application won't quit inside of unity editor.
        // Hence the debug log above. 
        Application.Quit(); 
    }
}
