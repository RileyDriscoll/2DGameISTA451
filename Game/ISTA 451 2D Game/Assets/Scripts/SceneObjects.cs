using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneObjects : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public static SceneObjects singlton;
    public GameObject[] difficultyGroups;
    public int[] requiredDifficulty;
    private Difficulty difficulty;
    // Use this for initialization
    void Start () {
        singlton = this;

        AdjustLevel();
        Singleton.tracker.gameObject.GetComponent<TimeTracker>().StartTimer();
    }
	
	// Update is called once per frame
	public void ChangeText (string newText) {
        timerText.text = newText;
	}

    private void AdjustLevel()
    {
        difficulty = Singleton.tracker.gameObject.GetComponent<Difficulty>();
        for(int i = 0; i < difficultyGroups.Length; i++)
        {
            if(requiredDifficulty[i] > difficulty.GetDifficulty())
            {
                difficultyGroups[i].SetActive(false);
            }
        }

    }
}
