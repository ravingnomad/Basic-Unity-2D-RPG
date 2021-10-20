using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndScreen : MonoBehaviour {

    public string area;

    void Start()
    {
        DontDestroyOnLoadManager.DestroyAll();
    }


	void Update () {
		if (Input.inputString == "e")
        {
            SceneManager.LoadScene(area);
        }
	}
}
