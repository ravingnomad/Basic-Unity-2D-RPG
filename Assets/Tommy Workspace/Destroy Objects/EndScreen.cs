using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    private void Update()
    {
        if (Input.inputString == "e")
        {
<<<<<<< HEAD
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            PlayerMove.Exists = false;
            PlayerCamera.Exists = false;
            MusicManager.Exists = false;
            SFXManager.Exists = false;
            DestroyManager.Exists = false;
            UIController.UIExists = false;
            SceneManager.LoadScene("Start Screen");
        }

=======
            SceneManager.LoadScene("Start Screen");
        }
>>>>>>> origin/master
        else if (Input.inputString == "q")
        {
            Application.Quit();
        }
    }
}
