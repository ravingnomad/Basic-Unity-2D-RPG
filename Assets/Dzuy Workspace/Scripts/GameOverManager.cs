using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private Animator anim;
<<<<<<< HEAD
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
=======

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
>>>>>>> origin/master
	}

    public void Quit()
    {
<<<<<<< HEAD
=======
        Debug.Log("Just quitted the game");
>>>>>>> origin/master
        anim.SetBool("Decided", true);
        Application.Quit();
    }

    public void Retry()
    {
<<<<<<< HEAD
        anim.SetBool("Decided", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        music.Tracks[4].Stop();
        MusicManager.Exists = false;
        //UIController.UIExists = false;
        Destroy(FindObjectOfType<DestroyManager>());
        Destroy(music);
=======
        Debug.Log("Retry from the beginning");
        anim.SetBool("Decided", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
>>>>>>> origin/master
        SceneManager.LoadScene("Start Screen");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
