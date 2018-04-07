using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInstantiator : MonoBehaviour {

    public static MusicInstantiator instance; //implementation of a singleton instance for the sound

    //call the instance on awake
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject); //this is used to maintain the gameObject or music across scenes
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); //if a duplicate of the gameObject is found then destroy it
        }
    }
}
