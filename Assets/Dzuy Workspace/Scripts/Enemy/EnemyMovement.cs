using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int moveSpeed = 3;
    public float waitTime;
    public float moveTime;
    public bool isMoving;

    private int walkDirection;
    private Rigidbody2D enemyRigidBody;
    private Animator animator;
    private Vector2 lastMove;
    private bool playSfxOnScreen; //only play sfx when on camera
    private SFXManager sfxManager; //mainly for slime SFX when moving


    void Start () {
        sfxManager = FindObjectOfType<SFXManager>();
        animator = GetComponent<Animator>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        isMoving = false;
        
        enemyRigidBody.velocity = Vector2.zero;
        waitTime = Random.Range(0, 4);
	}
	

	void Update () {

        if (isMoving == false)
        {
            moveTime = Random.Range(1, 4);
            freezeAnimationMovement();
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                isMoving = true;
                animator.SetBool("Moving", true);
                ChooseDirection();
            }
        }

        if (isMoving == true)
        {
            switch (walkDirection)
            {
                case 0:
                    enemyRigidBody.velocity = new Vector2( 0, moveSpeed);
                    lastMove = new Vector2(0, 1);
                    animator.SetFloat("Move X", 0);
                    animator.SetFloat("Move Y", 1);
                    break;
                case 1:
                    enemyRigidBody.velocity = new Vector2(0, -(moveSpeed));
                    lastMove = new Vector2(0, -1);
                    animator.SetFloat("Move X", 0);
                    animator.SetFloat("Move Y", -1);
                    break;
                case 2:
                    enemyRigidBody.velocity = new Vector2(moveSpeed, 0);
                    lastMove = new Vector2(1, 0);
                    animator.SetFloat("Move X", 1);
                    animator.SetFloat("Move Y", 0);
                    break;
                case 3:
                    enemyRigidBody.velocity = new Vector2( -(moveSpeed), 0);
                    lastMove = new Vector2(-1, 0);
                    animator.SetFloat("Move X", -1);
                    animator.SetFloat("Move Y", 0);
                    break;
            }
            if (gameObject.tag == "Slime" && sfxManager.SlimeMove.isPlaying == false && playSfxOnScreen == true)
            {
                sfxManager.SlimeMove.Play();
            }
            moveTime -= Time.deltaTime;
            if (moveTime <= 0)
            {
                waitTime = Random.Range(0, 4);
                isMoving = false;
            }
        }
	}

    public void freezeAnimationMovement()
    {
        isMoving = false;
        enemyRigidBody.velocity = Vector2.zero;
        animator.SetBool("Moving", false);
        animator.SetFloat("Last Move X", lastMove.x);
        animator.SetFloat("Last Move Y", lastMove.y);
    }


    //stop moving and reset waitCounter when enemy bumps into anything
    void OnCollisionEnter2D(Collision2D coll)
    {
        isMoving = false;
        waitTime = Random.Range(0,4);
    }

 
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4); //0 = up, 1 = down, 2 = right, 3 = left
    }


    private void OnBecameInvisible()
    {
        playSfxOnScreen = false;
    }


    private void OnBecameVisible()
    {
        playSfxOnScreen = true;
    }
}
