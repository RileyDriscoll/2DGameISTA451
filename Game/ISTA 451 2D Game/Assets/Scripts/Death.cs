using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    private TimeTracker timeTracker;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Kill")
        {
            timeTracker = Singleton.tracker.gameObject.GetComponent<TimeTracker>();
            timeTracker.LoseTime(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
