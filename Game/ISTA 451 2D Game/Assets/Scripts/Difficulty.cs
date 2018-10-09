using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour {

    public int difficulty;
   
    public int GetDifficulty()
    {
        return difficulty;
    }

    public void IncreaseDifficulty(int increase)
    {
        difficulty += increase;
    }

    public void SetDifficulty(int num)
    {
        difficulty = num;
    }

}
