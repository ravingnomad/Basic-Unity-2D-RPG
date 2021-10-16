using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public PlayerMove playerMoveScript;

	void Start () {
        playerMoveScript = FindObjectOfType<PlayerMove>();
        if (playerMoveScript.StartPoint == null)
        {
            playerMoveScript.transform.position = transform.position;
        }
	}
}
