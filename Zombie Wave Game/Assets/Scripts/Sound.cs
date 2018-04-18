using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

    private MusicInstantiator song;
    public Button SoundButton;
    public Button SoundFXButton;
    public Sprite MusicOn;
    public Sprite MusicOff;

    // Update is called once per frame
    void Start()
    {
        song = GameObject.FindObjectOfType<MusicInstantiator>();
        PauseMusic();
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
            SoundFX.PlayFX("AudioTick");
            AudioListener.volume = 1; //music plays
            SoundButton.GetComponent<Image>().sprite = MusicOn;
        
        }
        else
        {
            SoundFX.PlayFX("AudioTick");
            AudioListener.volume = 0; //music stops
            SoundButton.GetComponent<Image>().sprite = MusicOff;
        }
    }
}
