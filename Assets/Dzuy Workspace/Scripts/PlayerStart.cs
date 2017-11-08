using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour {

    private GameObject thePlayer;
    private GameObject theCamera;


	// Use this for initialization
	void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

        thePlayer.transform.position = transform.position;
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
