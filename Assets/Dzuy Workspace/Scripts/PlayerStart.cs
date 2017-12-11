using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour {

    public string pointName;

    public PlayerMove thePlayer;
    public PlayerCamera theCamera;


	// Use this for initialization
	void Awake () {
        thePlayer = FindObjectOfType<PlayerMove>();
        theCamera = FindObjectOfType<PlayerCamera>();
        if (thePlayer.StartPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
