using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public float timeGain;
    private TimeTracker timeTracker;
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timeTracker = Singleton.tracker.gameObject.GetComponent<TimeTracker>();
            Singleton.tracker.gameObject.GetComponent<Difficulty>().IncreaseDifficulty(1);
            timeTracker.GainTime(timeGain);
            timeTracker.StopTimer();
            SceneManager.LoadScene("OlmechLevelClear");
        }
    }
}
