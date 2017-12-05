using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
