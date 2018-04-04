using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour {

    public AudioClip SoundTrack; //current audioclip
    MusicPlayer musicSwitcher;

    // Use this for initialization
    void Start()
    {
        musicSwitcher = FindObjectOfType<MusicPlayer>(); //used to tie the level music gameobject to a variable so it can be utilized in the script

        if (SoundTrack != null) //basoc exception handling to ensure that music is only loaded if it exists
        {
            musicSwitcher.ChangeTrack(SoundTrack); //Calls the confirm script's change track method to change current song
        }
    }
}
