using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadNextLevel : MonoBehaviour {

    private string nextLevel;
    public float timer;
    public TextMeshProUGUI levelType;
    public TextMeshProUGUI level;
    
    // Use this for initialization
    void Start()
    {
        Singleton.tracker.gameObject.GetComponent<RandomLevel>().ChooseRandomLevel();
        nextLevel = Singleton.tracker.gameObject.GetComponent<RandomLevel>().GetNextLevel();
        if (!Singleton.tracker.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            Singleton.tracker.gameObject.GetComponent<AudioSource>().Play();
        }
    }
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        level.text = "Level: " + Singleton.tracker.gameObject.GetComponent<Difficulty>().GetDifficulty().ToString();

        if (nextLevel[0].Equals('D'))
        {
            levelType.text = "Double Jump";
        } else if (nextLevel[0].Equals('G'))
        {
            levelType.text = "Gravity Swap";
        }

        if (timer <= 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
	}
}
