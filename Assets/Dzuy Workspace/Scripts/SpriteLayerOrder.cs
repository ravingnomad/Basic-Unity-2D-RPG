using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerOrder : MonoBehaviour {

	private SpriteRenderer spriteRender;
	private Transform spriteTransform;

	void Start () {
		spriteTransform = GetComponent<Transform>();
		spriteRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		spriteRender.sortingOrder = (int)(spriteTransform.position.y * -15f);
	}
}
