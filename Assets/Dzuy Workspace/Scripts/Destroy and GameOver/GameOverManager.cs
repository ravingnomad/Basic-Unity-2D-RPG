using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private Animator animator;
    private MusicManager musicManager;


	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        animator = GetComponent<Animator>();
	}

    public void Quit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
    }

    public void Retry()
    {
        animator.SetBool("Decided", true);
        musicManager.Tracks[4].Stop();
        DontDestroyOnLoadManager.DestroyAll();
        SceneManager.LoadScene("Start Screen");
    }


}
