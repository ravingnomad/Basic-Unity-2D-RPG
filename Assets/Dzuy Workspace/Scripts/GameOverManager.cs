using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void Quit()
    {
        Debug.Log("Just quitted the game");
        anim.SetBool("Decided", true);
    }

    public void Retry()
    {
        Debug.Log("Retry from the beginning");
        anim.SetBool("Decided", true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
