using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransitions : MonoBehaviour {

    //panel located within main menu that allows player to exit game
    public GameObject exitpanel;

    public void PlayGameBtn ()
    {
        SceneManager.LoadScene(1);
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
