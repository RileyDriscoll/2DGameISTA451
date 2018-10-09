using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevel : MonoBehaviour {

    private string nextLevel;
    private string prevLevel;
    public string[] possibleLevels;

	void Awake () {
        prevLevel = "";
        possibleLevels = new string[] {"DoubleJumpLevel1", "GravSwapLevel1", "GravSwapLevel2", "DoubleJumpLevel2" };
	}

    public void ChooseRandomLevel()
    {
        if(!prevLevel.Equals(""))
        {
            int index = possibleLevels.Length;
            for(int i = 0; i < possibleLevels.Length; i++)
            {
                if (possibleLevels[i].Equals(prevLevel)){   
                    index = i;
                    
                }
            }

            if (index == possibleLevels.Length)
            {
                nextLevel = possibleLevels[Random.Range(0, possibleLevels.Length)];
            }
            else
            {
                int[] choices = new int[] { Random.Range(0, index), Random.Range(index + 1, possibleLevels.Length) };

                if(index == 0)
                {
                    nextLevel = possibleLevels[choices[1]];
                }
                else if (choices[1] >= possibleLevels.Length)
                {
                    nextLevel = possibleLevels[choices[0]];
                }
                else
                {
                    nextLevel = possibleLevels[choices[Random.Range(0, 2)]];
                }
            }
        }
        else
        {
            nextLevel = possibleLevels[Random.Range(0, possibleLevels.Length)];
        }
        prevLevel = nextLevel;
    }

    public string GetNextLevel()
    {
        return nextLevel;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
            Destroy(gameObject);
        }
    }

}
