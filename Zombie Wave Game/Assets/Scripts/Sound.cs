using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

    private MusicInstantiator song;
    

    // Update is called once per frame
    void Start()
    {
        song = GameObject.FindObjectOfType<MusicInstantiator>();
    }


    public void Pauser() //used to pause the music within the game
    {
        song.Initializer(); //calls the prefs to set whether or not music will be paused when pressed
        PauseMusic(); //based on the playerpref number an action is performed
    }

    void PauseMusic()
    {
        if (PlayerPrefs.GetInt("mutestate", 0) == 0)
        {
            AudioListener.volume = 1; //music plays
        
        }
        else
        {
            AudioListener.volume = 0; //music stops
           
        }
    }
}
