using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransitions : MonoBehaviour {

    //panel located within main menu that allows player to exit game
    public GameObject exitpanel;
    public GameObject pausepanel;


     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausepanel.SetActive(true);
        }
    }

    //all buttons correspond to a specific scene within the game and serve to transition between those scenes
    public void PlayGameBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsGameBtn()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //This exits the game
    public void OnExitClick()
    {
        exitpanel.SetActive(true);
    }

    //When Buttons on panel appear....
    public void NoExit()
    {
        exitpanel.SetActive(false); //makes panel dissapear
    }

    public void YesExit()
    {
        Application.Quit();
    }

}
