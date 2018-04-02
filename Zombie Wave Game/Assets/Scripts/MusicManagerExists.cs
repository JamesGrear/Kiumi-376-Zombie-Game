using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerExists : MonoBehaviour {

    //Use this for initialization
    //This is used in the case that the music manager does not exist within the current scene
    //It recreates it if it does not
    public GameObject LvlMu;
    void Start()
    {
        if (FindObjectOfType<MusicPlayer>())		//checks if the object does exist in the current scene and returns if it does
        {
            return;
        }
        else
        {
            Instantiate(LvlMu, transform.position, transform.rotation);		//if it doesn't it simply instantiates it into the scene
        }
    }
}
