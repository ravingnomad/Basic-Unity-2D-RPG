using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPosition;
    public float moveSpeed;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;
    private float clampedX;
    private float clampedY;

    public static bool Exists;
	// Use this for initialization
	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoadManager.SetDontDestroy(this.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * ((float)Screen.width / (float)Screen.height);
        clampedX = 0f;
        clampedY = 0f;
    }
	
	
	void Update () {
        if (boundBox == null)
        {
            boundBox = GameObject.FindGameObjectWithTag("Camera Bounds").GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        clampedX = Mathf.Clamp(targetPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        clampedY = Mathf.Clamp(targetPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        targetPosition = new Vector3(clampedX, clampedY, targetPosition.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
    }

    //sets new bounds for new scene
    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }
}
