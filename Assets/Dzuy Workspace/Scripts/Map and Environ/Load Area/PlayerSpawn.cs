using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public PlayerMove player;

	void Start () {
        player = FindObjectOfType<PlayerMove>();
        if (player.StartPoint == null)
        {
            player.transform.position = transform.position;
        }
	}
}
