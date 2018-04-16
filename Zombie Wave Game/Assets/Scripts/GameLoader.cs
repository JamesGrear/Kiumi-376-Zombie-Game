using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {

    //located within the game
    public GameObject loadingscreen; 
    public Slider loadingbar;

    public void LoadGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex)); //Calls coroutine
    }


    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingscreen.SetActive(true);

       while(!operation.isDone) //runs as long as operation not done
       {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingbar.value = progress; //sets the loading bar slider value to the operations progress


            yield return null; //waits a frame until we check status again
        }
    }
}
