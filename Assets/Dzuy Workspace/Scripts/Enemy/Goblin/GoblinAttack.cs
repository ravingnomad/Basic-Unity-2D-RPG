using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : EnemyAttack
{
    public Collider2D attackHitBox;
    public Rigidbody2D enemyBody;
    public EnemyMovement movement;
    public SFXManager sfx;


    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyChasing = GetComponent<EnemyChasePlayer>();
        movement = GetComponent<EnemyMovement>();
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Vector3 directionOfPlayer = (player.transform.position - transform.position).normalized;
        if (canAttackPlayer(distanceToPlayer, directionOfPlayer))
        {
            goblinAttack();
        }
        else
        {
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
        playGoblinAttackSFX();
        movement.enabled = false;
        enemyBody.velocity = Vector2.zero;
        attackPlayer();
        enemyChasing.enabled = true;
    }
}
