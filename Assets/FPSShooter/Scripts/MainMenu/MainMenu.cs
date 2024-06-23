using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
 
    public void PlayEasy()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("EasyScene", LoadSceneMode.Single);
    }
    public void PlayHard()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("NormalScene", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
