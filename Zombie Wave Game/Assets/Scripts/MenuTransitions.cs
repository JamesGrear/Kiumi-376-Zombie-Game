using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransitions : MonoBehaviour {

    //panel located within main menu that allows player to exit game
    public GameObject exitpanel;
<<<<<<< HEAD
    public GameObject pausepanel;
    public GameObject retrypanel;


     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SoundFX.PlayFX("Button");
            pausepanel.SetActive(true);
            Time.timeScale = 0f; //this stops both the enemy and player from moving
        }
    }

    public void ResumeGameBtn()
    {
        SoundFX.PlayFX("Button");
        pausepanel.SetActive(false);
        Time.timeScale = 1f; //this unpauses and reenables enemy and player movement
    }

    //all buttons correspond to a specific scene within the game and serve to transition between those scenes
    public void PlayGameBtn()
    {
        SoundFX.PlayFX("Button");
        SceneManager.LoadScene(1); 
    }

    public void RetryGameBtn()
=======

    //all buttons correspond to a specific scene within the game and serve to transition between those scenes
    public void PlayGameBtn ()
>>>>>>> master
    {
        SoundFX.PlayFX("Button");
        SceneManager.LoadScene(1);
    }

    public void SettingsGameBtn()
    {
<<<<<<< HEAD
        SoundFX.PlayFX("Button");
        SceneManager.LoadScene(2); 
=======
        SceneManager.LoadScene(2);
>>>>>>> master
    }

    public void MainMenu()
    {
        SoundFX.PlayFX("Button");
        SceneManager.LoadScene(0);
    }


    //This exits the game
    public void OnExitClick()
    {
        SoundFX.PlayFX("Button");
        exitpanel.SetActive(true);
    }

    //When Buttons on panel appear....
    public void NoExit()
    {
        SoundFX.PlayFX("Button");
        exitpanel.SetActive(false); //makes panel dissapear
    }

    public void YesExit()
    {
        SoundFX.PlayFX("Button");
        Application.Quit();
    }

}
