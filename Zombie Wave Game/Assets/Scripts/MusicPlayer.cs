using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour {

    public Toggle MusicPauser; //set to the toggle gameobject within the settings
    public AudioSource musicContainer; //current music being played is held in this variable
    private int mute; //acts as a container for the shared prefences value set on the toggling on music on/off
    //GameObject GrabToggle; //grabs the actual toggle object

   /* void Awake()
    {
        try
        {
            GrabToggle = GameObject.Find("SoundToggle");
            MusicPauser = GrabToggle.gameObject.GetComponent<Toggle>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Reference not found" + e);
        }

        Initializer();
    }

    public void Initializer()
    {

        mute = PlayerPrefs.GetInt("mutestate");
        if (mute == 0)
        {
            MusicPauser.isOn = true;
        }
        else
        {
            MusicPauser.isOn = false;
        }

    }


    public void Pauser() //used to pause the music within the game
    {
        //checks if the music is playing when toggle is clicked and pauses it if so if it is not it will unpause the music to play it
        if (MusicPauser.isOn) //checks if music is indeed playing
        {
            musicContainer = GameObject.Find("MusicManager").GetComponent<AudioSource>();
            musicContainer.Pause(); //pauses the music if music is playing
            PlayerPrefs.SetInt("mutestate", 0);

        }
        else
        {
            musicContainer = GameObject.Find("MusicManager").GetComponent<AudioSource>();
            musicContainer.UnPause(); //unpauses the music if music is not playing    
            PlayerPrefs.SetInt("mutestate", 1);
        }
    }*/

    public void ChangeTrack(AudioClip music) //this is used to change the current audio clip played within a scene
    {
        if (musicContainer.clip.name != music.name) //condition that checks for whether or not the current song is the same                                                   
        {                                           //as the song that is to be played so that it doesnt restart a song currently playing if its the same
            if (musicContainer.isPlaying)
            {
                musicContainer.Stop(); //stops current clip
                musicContainer.clip = music; //resets clip to new song given in the inspector
                musicContainer.Play(); //plays the new song
            }
        }
    }
}
