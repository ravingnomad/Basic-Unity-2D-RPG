﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
<<<<<<< HEAD

=======
>>>>>>> origin/master
    public GameObject followTarget;
    private Vector3 targetPosition;
    public float moveSpeed;

<<<<<<< HEAD
    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    public static bool Exists;
	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(transform.gameObject);
=======
    public static bool Exists;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
>>>>>>> origin/master

        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
<<<<<<< HEAD
        //boundBox = GameObject.FindGameObjectWithTag("Camera Bounds").GetComponent<BoxCollider2D>();
        //minBounds = boundBox.bounds.min;
        //maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * (Screen.width / Screen.height);
=======
>>>>>>> origin/master
    }
	
	// Update is called once per frame
	void Update () {
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
<<<<<<< HEAD

        if (boundBox == null)
        {
            boundBox = GameObject.FindGameObjectWithTag("Camera Bounds").GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    //sets new bounds for new scene
    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
=======
>>>>>>> origin/master
    }
}
