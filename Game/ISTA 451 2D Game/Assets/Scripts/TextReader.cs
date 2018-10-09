using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextReader : MonoBehaviour {

    public string[] textToRead;
    private int textIndex;
    private int prevIndex;
    private float index;
    public float baseReadSpeed;
    private float curReadSpeed;
    public TextMeshProUGUI timerText;

    // Use this for initialization
    void Start () {
        index = 0;
        textIndex = 0;
        prevIndex = 0;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space"))
        {
            curReadSpeed = baseReadSpeed * 2;
        }
        else
        {
            curReadSpeed = baseReadSpeed;
        }
        if (Mathf.Floor(index) < textToRead[textIndex].Length) {
            
            index += curReadSpeed * Time.deltaTime;
            timerText.text = textToRead[textIndex].Substring(0, Mathf.RoundToInt(Mathf.Floor(index)));
            if (prevIndex != Mathf.RoundToInt(Mathf.Floor(index)))
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            prevIndex = Mathf.RoundToInt(Mathf.Floor(index));

        }
        else
        {
            timerText.text = textToRead[textIndex];
            if (Input.GetKeyDown("space"))
            {
                if(textIndex < textToRead.Length)
                {
                    textIndex++;
                    index = 0;
                }
                if(textIndex == textToRead.Length)
                {
                    SceneManager.LoadScene("BeforeLevel");
                }
            }
        }

        
	}
}
