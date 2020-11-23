using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static bool Exists;
    public AudioSource[] Tracks;
    public int currentTrack;
    public bool musicCanPlay;

	// Use this for initialization
	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (musicCanPlay == true)
        {
            if (Tracks[currentTrack].isPlaying == false)
            {
                Tracks[currentTrack].Play();
            }
        }

        else {
            Tracks[currentTrack].Stop();
        }
	}

    public void SwitchTrack(int newTrack)
    {
        Tracks[currentTrack].Stop();
        currentTrack = newTrack;
        Tracks[currentTrack].Play();
    }
}
