using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToStartScreen : MonoBehaviour {


	private void Start ()
    {
        StartCoroutine(Wait());

	}
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("Start Screen");
    }
	
}
