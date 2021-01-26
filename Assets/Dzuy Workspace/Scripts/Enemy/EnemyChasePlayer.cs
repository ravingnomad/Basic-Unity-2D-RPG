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
        if (aggroed == true)
        {
            chasePlayer();
        }
        else if (playerInAggroDistance() || hitByPlayer)
        {
            enemyMovementScript.enabled = false;
            aggroed = true;
        }
	}


    private bool playerInAggroDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position) <= aggroDistance;
    }


    private void chasePlayer()
    {
        enemyMoving = true;
        Vector3 playerDirection = player.transform.position - transform.position;
        Vector3 normalized = playerDirection.normalized;
        lastMove = new Vector2(normalized.x, normalized.y);
        enemyBody.velocity = new Vector2(normalized.x * moveSpeed, normalized.y * moveSpeed);

        anim.SetFloat("Move X", normalized.x);
        anim.SetFloat("Move Y", normalized.y);
        anim.SetBool("Moving", enemyMoving);

        if (playerInAggroDistance() == false && hitByPlayer == false)
        {
            turnOffEnemyAggro();
        }
    }


    private void turnOffEnemyAggro()
    {
        aggroed = false;
        enemyMoving = false;
        enemyMovementScript.enabled = true;
        anim.SetBool("Moving", false);
        anim.SetFloat("Last Move X", lastMove.x);
        anim.SetFloat("Last Move Y", lastMove.y);
        enemyBody.velocity = Vector2.zero;
    }
}
