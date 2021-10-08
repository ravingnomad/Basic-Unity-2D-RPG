using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : EnemyAttack
{
    public Collider2D attackHitBox;
    public Rigidbody2D enemyBody;
    public EnemyMovement enemyMovementScript;
    public SFXManager sfx;
    public float attackAnimLengthSec;
    public float waitForNextAttack;
    public bool sfxPlayed;


    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyChasing = GetComponent<EnemyChasePlayer>();
        enemyMovementScript = GetComponent<EnemyMovement>();
        sfxPlayed = false;
        waitForNextAttack = 0.0f;
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Vector3 directionOfPlayer = (player.transform.position - transform.position).normalized;
        if (waitForNextAttack <= 0.0f)
        {
            if (canAttackPlayer(distanceToPlayer, directionOfPlayer))
                goblinAttack();
            enemyMovementScript.enabled = true;
            enemyChasing.enabled = true;
        }
        else if (waitForNextAttack > 0.0f)
        {
            enemyBody.velocity = Vector2.zero;
            enemyMovementScript.enabled = false;
            enemyChasing.enabled = false;
            waitForNextAttack -= Time.deltaTime;
            animator.SetBool("Attacking", false);
            //animator.SetBool("Moving", false);
        }
        else
        {
            //waitForNextAttack = 0.0f;
            animator.SetBool("Moving", true);
            animator.SetBool("Attacking", false);
        }
    }


    private void playGoblinAttackSFX()
    {
        int attackSound = Random.Range(1, 3);
        if (attackSound == 1)
        {
            sfx.GoblinAttack_1.Play();
        }

        if (attackSound == 2)
        {
            sfx.GoblinAttack_2.Play();
        }
    }


    private void goblinAttack()
    {
        attackPlayer();
        playGoblinAttackSFX();
        waitForNextAttack = attackAnimLengthSec;
    }
}
