using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBeforeLevel : MonoBehaviour {

    private void Start()
    {
        this.GetComponent<AudioSource>().Play();
        Singleton.tracker.gameObject.GetComponent<AudioSource>().Pause();
    }
    // Update is called once per frame
    void Update () {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            Singleton.tracker.gameObject.GetComponent<AudioSource>().UnPause();
            SceneManager.LoadScene("BeforeLevel");
        }
	}
}
