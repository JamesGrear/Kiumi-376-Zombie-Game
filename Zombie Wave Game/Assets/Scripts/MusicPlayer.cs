using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour {

    public AudioSource musicContainer; //current music being played is held in this variable
 
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
