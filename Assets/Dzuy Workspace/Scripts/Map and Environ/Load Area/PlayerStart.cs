using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour {

    public string pointName;

    public GameObject thePlayer = null;
    public GameObject theCamera = null;

    void Start() {
        thePlayer = GameObject.FindWithTag("Player");
        theCamera = GameObject.FindWithTag("MainCamera");
        if (thePlayer.GetComponent<PlayerMove>().StartPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}
}
