using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour {

    private GameObject player;
    private PlayerAttack attackScript;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        attackScript = player.GetComponent < PlayerAttack>();
    }

    //Turn off collider when not attacking
    //only turn on when attacking == true
    //make another function in mc attack that returns true if the character is attacking
    //put it in this update function so as to check everytime if player is attacking
    void OnTriggerEnter2D(Collider2D col)
    {
        print("Hit the enemy!");
        if (col.gameObject.tag == "Enemy")
        {
          //  print("Hit the enemy");
        }
    }

    void Test()
    {
        //print("SUCCESS: Detected player attacking!");
    }
	// Update is called once per frame
	void Update () {
        if (attackScript.isAttacking())
        {
            Test();

        }
	}
}
