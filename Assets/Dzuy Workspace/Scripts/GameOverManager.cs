using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private Animator anim;
    private MusicManager music;
    private SFXManager sfx;

	// Use this for initialization
	void Start () {
        music = FindObjectOfType<MusicManager>();
        sfx = FindObjectOfType<SFXManager>();
        anim = GetComponent<Animator>();
        if (FindObjectOfType<PlayerCamera>() != null)
        {
            Destroy(FindObjectOfType<PlayerCamera>());
        }
	}

    public void Quit()
    {
        if (Application.isEditor)
        {
            anim.SetBool("Decided", true);
            UnityEditor.EditorApplication.isPlaying = false;
        }

        else
        {
            anim.SetBool("Decided", true);
            Application.Quit();
        }
        
    }

    public void Retry()
    {
        anim.SetBool("Decided", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        music.Tracks[4].Stop();
        MusicManager.Exists = false;
        //UIController.UIExists = false;
        Destroy(FindObjectOfType<DestroyManager>());
        Destroy(music);
        SceneManager.LoadScene("Start Screen");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
