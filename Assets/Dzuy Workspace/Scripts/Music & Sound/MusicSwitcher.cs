using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    public int switchToTrackNumber;
    public bool switchOnStart;

    private MusicManager musicManager;

	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        if (switchOnStart == true && musicManager.Tracks[switchToTrackNumber].isPlaying == false)
        {
            switchTrack(switchToTrackNumber);
            gameObject.SetActive(false);
        }
	}


    //if player ever enters a zone in a level
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchTrack(switchToTrackNumber);
            gameObject.SetActive(false);
        }
    }


    public void switchTrack(int newTrack)
    {
        musicManager.stopTrack();
        musicManager.switchTrack(switchToTrackNumber);
        musicManager.playTrack();
    }
}
