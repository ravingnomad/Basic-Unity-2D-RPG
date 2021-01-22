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

    public bool wasHit;
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
        else
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= aggroDistance)
            {
                enemyMovementScript.enabled = false;
                aggroed = true;
            }
        }
	}


    private void chasePlayer()
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
            enemyMovementScript.enabled = true;
            anim.SetBool("Moving", false);
            anim.SetFloat("Last Move X", normalized.x);
            anim.SetFloat("Last Move Y", normalized.y);
            enemyBody.velocity = Vector2.zero;

        }
    }
}
