using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private Animator anim;
    public bool isMoving; //if character is/not moving, change to appropraite animation
    public float shootTime; //how long until next shot is fired
    public float shootTimeCounter;
    
    private SpawnBullets spawner;
    private Rigidbody2D playerRigid;
    private Vector2 faceDirection;
    private GameObject player;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        spawner = player.GetComponentInChildren<SpawnBullets>();
        spawner.isFiring = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Period))
        {
            faceDirection = player.GetComponent<PlayerMove>().GetLastMove();
            //isMoving = player.GetComponent<PlayerMove>().moving();
            shootTimeCounter = shootTime;
            

            anim.SetBool("Shooting", true);
            //anim.SetBool("Player Moving", isMoving);
            anim.SetFloat("Last Move X", faceDirection.x);
            anim.SetFloat("Last Move Y", faceDirection.y);
            spawner.isFiring = true;
        }


        //don't want player to move while attacking
        //so disable PlayerMove script while attacking
        if (shootTimeCounter > 0)
        {
            shootTimeCounter -= Time.deltaTime;
            player.GetComponent<PlayerMove>().enabled = false;
            playerRigid.velocity = Vector2.zero;
        }

        if (shootTimeCounter <= 0)
        {
           
            //attackTrigger.enabled = false;
            anim.SetBool("Shooting", false);
            player.GetComponent<PlayerMove>().enabled = true;
            spawner.isFiring = false;
            spawner.firedOnce = false;
        }
    }
}
