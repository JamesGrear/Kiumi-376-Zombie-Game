using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {
    public static AudioClip Gun, BtnPress,audiotic; //audio played within the game
    static AudioSource SoundChime; //holds the sounds being played by the object

    void Start()
    {
        Gun = Resources.Load<AudioClip>("Gun");
        BtnPress = Resources.Load<AudioClip>("Button");
        audiotic = Resources.Load<AudioClip>("AudioTick");

        SoundChime = GetComponent<AudioSource>();

    }

    public static void PlayFX(string sound)
    {
        switch (sound)
        {
            case "AudioTick":
                SoundChime.PlayOneShot(audiotic);
                break;
            case "Gun":
                SoundChime.PlayOneShot(Gun);
                break;
            case "Button":
                SoundChime.PlayOneShot(BtnPress);
                break;
        }
    }
}
