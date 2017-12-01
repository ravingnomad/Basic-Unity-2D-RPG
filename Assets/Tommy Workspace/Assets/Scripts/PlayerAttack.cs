using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool Attacking;

    //attackTime is how long until attack is done
    //set Attacking to false
    //attackTimeCounter is the countdown
    public float attackTime;
    public Collider2D attackTrigger;
    public SpriteRenderer weaponSprite;

    private float attackTimeCounter;
    private GameObject player;
    private Animator anim;
    private Rigidbody2D playerRigid;

    //used to communicate with other scripts on whether the player is attacking or not
    public bool isAttacking()
    {
        return Attacking;
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();

        attackTrigger.enabled = false;
        weaponSprite.enabled = false;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void InflictDamage()
    {
        
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            Vector2 faceDirection = player.GetComponent<PlayerMove>().GetLastMove();

            //if player is just starting, set the attack direction to down (because the default sprite is looking down)
            if (faceDirection == Vector2.zero)
            {
                faceDirection = new Vector2(0, -1);
            }

            attackTimeCounter = attackTime;
            Attacking = true;
            attackTrigger.enabled = true;
            weaponSprite.enabled = true;
            

            //animates movement based on direction facing
            anim.SetBool("Attacking", true);
            anim.SetFloat("Last Move X", faceDirection.x);
            anim.SetFloat("Last Move Y", faceDirection.y);
            InflictDamage();
        }

        //countdown to know when to end attack animation
        //don't want player to move while attacking
        //so disable PlayerMove script while attacking
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
            player.GetComponent<PlayerMove>().enabled = false;
            playerRigid.velocity = Vector2.zero;
        }

        if (attackTimeCounter <= 0)
        {
            weaponSprite.enabled = false;
            attackTrigger.enabled = false;
            Attacking = false;
            anim.SetBool("Attacking", false);
            player.GetComponent<PlayerMove>().enabled = true;
        }
	}
}
