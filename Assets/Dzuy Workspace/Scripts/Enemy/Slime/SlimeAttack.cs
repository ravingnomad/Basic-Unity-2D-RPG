using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : EnemyAttack
{
    public Collider2D attackHitBox;
    public Rigidbody2D enemyBody;
    public EnemyMovement enemyMovementScript;
    public SFXManager sfx;
    public bool slimeAbleToAttack;
    public bool slimeCanMove;


    void Start()
    {
        slimeAbleToAttack = true;
        slimeCanMove = true;
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyChasing = GetComponent<EnemyChasePlayer>();
        enemyMovementScript = GetComponent<EnemyMovement>();
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
        enemyChasing.enabled = true;
        enemyMovementScript.enabled = true;
        slimeCanMove = true;
    }


    private void slimeAttack()
    {
        enemyMovementScript.enabled = false;
        enemyBody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        attackPlayer();
        slimeCanMove = false;
    }

}
