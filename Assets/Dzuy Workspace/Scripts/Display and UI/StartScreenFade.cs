using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenFade : MonoBehaviour {


	private void Start ()
    {
        StartCoroutine(Wait());

	}
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("Start Screen");
    }
	
}
