using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static bool Exists;
    public AudioSource[] Tracks;
    public int currentTrack;
    public bool musicCanPlay;


	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoadManager.SetDontDestroy(this.gameObject);
        }
        else
            Destroy(gameObject);
    }
	

	void Update () {
        if (musicCanPlay == true && Tracks[currentTrack].isPlaying == false)
            playTrack();
        if (musicCanPlay == false) 
            stopTrack();
	}


    public void playTrack()
    {
        Tracks[currentTrack].Play();
    }


    public void stopTrack()
    {
        Tracks[currentTrack].Stop();
    }


    public void switchTrack(int newTrackNumber)
    {
        currentTrack = newTrackNumber;
    }
}
