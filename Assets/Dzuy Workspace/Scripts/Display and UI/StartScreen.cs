using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public string area;

	void Update () {
		if (Input.inputString == "e")
        {
            SceneManager.LoadScene(area);
        }
	}
}
