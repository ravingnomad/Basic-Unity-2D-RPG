using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ScreenCapture.CaptureScreenshot("Promotional Material.png");
	}
	
}
