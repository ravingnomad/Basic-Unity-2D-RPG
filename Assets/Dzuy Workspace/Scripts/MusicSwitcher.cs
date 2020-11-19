using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    private MusicManager musicManager;

    public int newTrack;

    public bool switchOnStart;


	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        if (switchOnStart == true && musicManager.Tracks[newTrack].isPlaying == false)
        {
            musicManager.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
	}


    //if player ever enters a zone in a level
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            musicManager.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
