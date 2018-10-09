using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour {

    public static Singleton tracker;
	// Use this for initialization
	void Awake () {
		if(tracker != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            tracker = this;
            DontDestroyOnLoad(this.gameObject);
        }
	}
	
}
