using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    public BoxCollider2D boxCollider;
    public PlayerCamera theCamera;

	// Use this for initialization
	void Start () {
        
        boxCollider = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<PlayerCamera>();
        theCamera.SetBounds(boxCollider);
	}
}
