using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : EnemyAttack
{
    private Rigidbody2D enemyBody;
    private EnemyMovement enemyMovementScript;
    private SFXManager sfx;
    private bool slimeAbleToAttack;
    private bool slimeCanMove;
    private EnemyHealth slimeHealth;


    void Start()
    {
        //These three are inherited from parent
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyChaseScript = GetComponent<EnemyChasePlayer>();

        slimeAbleToAttack = true;
        slimeCanMove = true;
        enemyBody = GetComponent<Rigidbody2D>();
        enemyMovementScript = GetComponent<EnemyMovement>();
        slimeHealth = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Vector3 directionOfPlayer = (player.transform.position - transform.position).normalized;
        if (slimeAbleToAttack && canAttackPlayer(distanceToPlayer, directionOfPlayer))
        {
            slimeAbleToAttack = false;
            slimeAttack();
            StartCoroutine(pauseAttack());
        }
        else
        {
            if (slimeCanMove)
                animator.SetBool("Moving", true);
            animator.SetBool("Attacking", false);
        }
    }


    IEnumerator pauseAttack()
    {
        yield return new WaitForSeconds(3);
        slimeAbleToAttack = true;
        enemyBody.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        if (slimeIsDead() == false)
        {
            enemyChaseScript.enabled = true;
            enemyMovementScript.enabled = true;
            slimeCanMove = true;
        }
    }


    private bool slimeIsDead()
    {
        return slimeHealth.isDead();   
    }


    private void slimeAttack()
    {
        enemyMovementScript.enabled = false;
        enemyBody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        attackPlayer();
        slimeCanMove = false;
    }

}
