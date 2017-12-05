using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChase : MonoBehaviour {

    public float aggroDistance;
    public GameObject player;
    public int moveSpeed;
    public float chaseTimer;
    public bool aggroed;
    public EnemyMovement enemyMovement;

    public bool wasHit; //if enemy was hit by the player, keep chasing them; otherwise if not hit and out of aggro range, then stop
    private Animator anim;
    private bool enemyMoving;
    private Vector2 lastMove;
    private Rigidbody2D enemyBody;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        enemyMovement = GetComponent<EnemyMovement>();
        enemyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aggroed = false;
        lastMove = new Vector2(0, -1);
    }
	
	// Update is called once per frame
	void Update () {

        //if enemy is aggroed, keep chasing player
        if (aggroed == true)
        {
            enemyMoving = true;
            Vector3 direction = player.transform.position - transform.position;
            Vector3 normalized = direction.normalized;
            lastMove = new Vector2(normalized.x, normalized.y);
            enemyBody.velocity = new Vector2(normalized.x * moveSpeed, normalized.y * moveSpeed);

            anim.SetFloat("Move X", normalized.x);
            anim.SetFloat("Move Y", normalized.y);
            anim.SetBool("Moving", enemyMoving);

            if (Vector3.Distance(player.transform.position, transform.position) > aggroDistance && wasHit == false)
            {
                aggroed = false;
                enemyMoving = false;
                enemyMoving = false;
                enemyMovement.enabled = true;
                anim.SetBool("Moving", false);
                anim.SetFloat("Last Move X", normalized.x);
                anim.SetFloat("Last Move Y", normalized.y);

                enemyBody.velocity = Vector2.zero;
               
            }
        }


        //if not aggroed, keep measuring distance between enemy and player
        else
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= aggroDistance)
            {
                enemyMovement.enabled = false;
                aggroed = true;
            }
        }

	}
}
