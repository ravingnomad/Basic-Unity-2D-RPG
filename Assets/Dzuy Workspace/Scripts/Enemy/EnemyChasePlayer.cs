using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour {

    public float aggroDistance;
    public GameObject player;
    public int moveSpeed;
    public float chaseTimer;
    public bool aggroed;
    public EnemyMovement enemyMovementScript;
    public bool hitByPlayer;

    private Animator anim;
    private bool enemyMoving;
    private Vector2 lastMove;
    private Rigidbody2D enemyBody;
    

	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        enemyMovementScript = GetComponent<EnemyMovement>();
        enemyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aggroed = false;
        lastMove = new Vector2(0, -1);
    }


	void Update ()
    {
        if (playerInAggroDistance() || hitByPlayer)
        {
            enemyMovementScript.enabled = false;
            chasePlayer();
            aggroed = true;
        }

        else if (playerInAggroDistance() == false && hitByPlayer == false)
        {
            turnOffEnemyAggro();
        }
    }


    private bool playerInAggroDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position) <= aggroDistance;
    }


    private void chasePlayer()
    {
        enemyMoving = true;
        enemyMovementScript.enabled = false;
        Vector3 playerDirection = player.transform.position - transform.position;
        Vector3 normalizedPlayerDirection = playerDirection.normalized;
        lastMove = new Vector2(normalizedPlayerDirection.x, normalizedPlayerDirection.y);
        enemyBody.velocity = new Vector2(normalizedPlayerDirection.x * moveSpeed, normalizedPlayerDirection.y * moveSpeed);
        anim.SetFloat("Move X", lastMove.x);
        anim.SetFloat("Move Y", lastMove.y);
        anim.SetBool("Moving", enemyMoving);
    }


    private void turnOffEnemyAggro()
    {
        aggroed = false;
        //for when enemy is chasing the player and need them to stop chasing
        if (enemyMoving == true)
            freezeAnimationMovement();
        enemyMoving = false;
        enemyMovementScript.enabled = true;
    }


    public void freezeAnimationMovement()
    {
        enemyBody.velocity = Vector2.zero;
        anim.SetBool("Moving", false);
        anim.SetFloat("Last Move X", lastMove.x);
        anim.SetFloat("Last Move Y", lastMove.y);
    }
}
