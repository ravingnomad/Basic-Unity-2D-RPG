using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool Attacking;

    //attackTime is how long until attack is done
    //set Attacking to false
    //attackTimeCounter is the countdown
    public float attackTime;

    private float attackTimeCounter;
    private GameObject player;
    private Animator anim;
    private Rigidbody2D playerRigid;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Comma) || Input.GetKeyDown(KeyCode.Period))
        {
            print("Here");
            Vector2 faceDirection = player.GetComponent<PlayerMove>().GetLastMove();

            //if player is just starting, set the attack direction to down (because the default sprite is looking down)
            if (faceDirection == Vector2.zero)
            {
                faceDirection = new Vector2(0, -1);
            }
            attackTimeCounter = attackTime;
            Attacking = true;

            //don't want player to move while attacking
            //so disable PlayerMove script while attacking
            player.GetComponent<PlayerMove>().enabled = false;
            playerRigid.velocity = Vector2.zero;

            //animates movement based on direction facing
            anim.SetBool("Attacking", true);
            anim.SetFloat("Last Move X", faceDirection.x);
            anim.SetFloat("Last Move Y", faceDirection.y);
        }

        //countdown to know when to end attack animation
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            Attacking = false;
            anim.SetBool("Attacking", false);
            player.GetComponent<PlayerMove>().enabled = true;
        }
	}
}
