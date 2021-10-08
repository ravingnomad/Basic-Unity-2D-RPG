using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : EnemyAttack
{
    private EnemyMovement enemyMovementScript;
    private SFXManager sfxManager;

    public float attackAnimLengthSec;
    public float waitForNextAttack;


    void Start()
    {
        //These three are inherited from parent
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyChaseScript = GetComponent<EnemyChasePlayer>();

        sfxManager = FindObjectOfType<SFXManager>();
        enemyMovementScript = GetComponent<EnemyMovement>();
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
            enemyChaseScript.enabled = true;
        }
        else if (waitForNextAttack > 0.0f)
        {
            animator.SetBool("Attacking", false);
            enemyMovementScript.freezeAnimationMovement();
            enemyMovementScript.enabled = false;
            enemyChaseScript.freezeAnimationMovement();
            enemyChaseScript.enabled = false;
            waitForNextAttack -= Time.deltaTime;
        }
        else
        {
            animator.SetBool("Moving", true);
            animator.SetBool("Attacking", false);
        }
    }

    private void goblinAttack()
    {
        attackPlayer();
        playGoblinAttackSFX();
        waitForNextAttack = attackAnimLengthSec;
    }

    private void playGoblinAttackSFX()
    {
        int attackSound = Random.Range(1, 3);
        if (attackSound == 1)
        {
            sfxManager.GoblinAttack_1.Play();
        }

        if (attackSound == 2)
        {
            sfxManager.GoblinAttack_2.Play();
        }
    }
}
