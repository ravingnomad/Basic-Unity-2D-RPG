using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private Animator animator;
    private MusicManager musicManager;
    private SFXManager sfxManager;


	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        sfxManager = FindObjectOfType<SFXManager>();
        animator = GetComponent<Animator>();
        if (FindObjectOfType<PlayerCamera>() != null)
        {
            Destroy(FindObjectOfType<PlayerCamera>());
        }
	}

    public void Quit()
    {
        if (Application.isEditor)
        {
            animator.SetBool("Decided", true);
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        else
        {
            animator.SetBool("Decided", true);
            Application.Quit();
        }
        
    }

    public void Retry()
    {
        animator.SetBool("Decided", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        
        musicManager.Tracks[4].Stop();
        Destroy(GameObject.FindGameObjectWithTag("Dialogue Box Canvas"));
        DialogueManager.Exists = false;
        Destroy(FindObjectOfType<DialogueManager>().gameObject);
        Destroy(FindObjectOfType<DestroyManager>().gameObject);
        SceneManager.LoadScene("Start Screen");
    }
}
