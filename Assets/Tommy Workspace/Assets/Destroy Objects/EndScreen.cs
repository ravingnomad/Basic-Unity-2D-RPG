using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    private void Update()
    {
        if (Input.inputString == "e")
        {
            SceneManager.LoadScene("Start Screen");
        }
        else if (Input.inputString == "q")
        {
            Application.Quit();
        }
    }
}
