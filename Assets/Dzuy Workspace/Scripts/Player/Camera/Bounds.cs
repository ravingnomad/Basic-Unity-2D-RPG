using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    public BoxCollider2D boxCollider;
    public PlayerCamera theCamera;

	// Use this for initialization
	void Start () {
        
        boxCollider = GetComponent<BoxCollider2D>();
        print("Collider bounds: " + boxCollider.bounds);
        print("Collider bounds center: " + boxCollider.bounds.center);
        print("Collider bounds size: " + boxCollider.bounds.size);
        print("Collider bounds minimum: " + boxCollider.bounds.min);
        print("Collider bounds maximum: " + boxCollider.bounds.max);
        theCamera = FindObjectOfType<PlayerCamera>();
        theCamera.SetBounds(boxCollider);
	}
}
