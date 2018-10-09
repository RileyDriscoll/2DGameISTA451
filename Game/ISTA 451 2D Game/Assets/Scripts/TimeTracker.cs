using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour {

    public float minutes;
    public float seconds;
    public bool stop;
    private SceneObjects timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!stop)
        {
            
            seconds -= Time.deltaTime;
            if (seconds < 0f)
            {
                seconds = 60f + seconds;
                minutes -= 1f;
            }
            if (seconds > 60f)
            {
                seconds = seconds - 60f;
                minutes += 1f;
            }

            if (minutes < 0f)
            {
                SceneManager.LoadScene("MainMenu");
            }

            timer = SceneObjects.singlton;
            timer.ChangeText(minutes + ":" + Mathf.Floor(seconds).ToString("00"));

            
        }
	}

    public void LoseTime(float timeLoss)
    {
        seconds -= timeLoss;
    }

    public void GainTime(float timeGain)
    {
        seconds += timeGain;
    }

    public void StopTimer()
    {
        stop = true;
    }

    public void StartTimer()
    {
        stop = false;
    }
}
