using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //public static bool Paused =false;
   // public GameObject PauseMenuCanvas;
   // public GameObject PlayerUI;
   // public GameObject AnythingNeedDisapear;
   // public GameObject NewCamera;

    void Start()
    {
       // Time.timeScale = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //if (Paused)
            //{
             //   Play();
           // }
           // else
           // {
                Stop();
            //}
        }

    }


    void Stop()
    {
       // NewCamera.SetActive(true);
      //  AnythingNeedDisapear.SetActive(false);
        //PlayerUI.SetActive(false);
       // PauseMenuCanvas.SetActive(true);
       // Time.timeScale = 0f;
       // Paused = true;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

  // public void Play()
   // {
        //NewCamera.SetActive(false);
       // AnythingNeedDisapear.SetActive(true );
       // PlayerUI.SetActive(true);
       // PauseMenuCanvas.SetActive(false);
        //Time.timeScale = 1f;
        //Paused=false;
        //SceneManager.LoadScene("MainMenu");
   // }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
