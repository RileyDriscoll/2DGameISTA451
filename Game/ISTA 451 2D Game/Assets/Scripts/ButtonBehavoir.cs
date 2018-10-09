using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavoir : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("OlmechMain");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
