using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int moveSpeed = 3;
    public float waitTime;
    public float waitCounter;
    public float moveTime;
    public float moveCounter;

    private int walkDirection;
    private Rigidbody2D enemyBody;
    private Animator anim;
    public bool isMoving;
    private Vector2 lastMove;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        isMoving = false;
        
        enemyBody.velocity = Vector2.zero;
        waitCounter = Random.Range(0, 4);
	}
	
	// Update is called once per frame
	void Update () {

        if (isMoving == false)
        {
            moveCounter = Random.Range(1, 4); ;
            anim.SetBool("Moving", false);
            anim.SetFloat("Last Move X", lastMove.x);
            anim.SetFloat("Last Move Y", lastMove.y);
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                isMoving = true;
                anim.SetBool("Moving", true);
                ChooseDirection();
            }
        }

        if (isMoving == true)
        {
            switch (walkDirection)
            {
                case 0:
                    enemyBody.velocity = new Vector2( 0, moveSpeed);
                    lastMove = new Vector2(0, 1);
                    anim.SetFloat("Move X", 0);
                    anim.SetFloat("Move Y", 1);
                    break;

                case 1:
                    enemyBody.velocity = new Vector2(0, -(moveSpeed));
                    lastMove = new Vector2(0, -1);
                    anim.SetFloat("Move X", 0);
                    anim.SetFloat("Move Y", -1);
                    break;

                case 2:
                    enemyBody.velocity = new Vector2(moveSpeed, 0);
                    lastMove = new Vector2(1, 0);
                    anim.SetFloat("Move X", 1);
                    anim.SetFloat("Move Y", 0);
                    break;

                case 3:
                    enemyBody.velocity = new Vector2( -(moveSpeed), 0);
                    lastMove = new Vector2(-1, 0);
                    anim.SetFloat("Move X", -1);
                    anim.SetFloat("Move Y", 0);
                    break;
            }

            //move for as long as this is greater than 0; once at zero, reset the waitCounter
            moveCounter -= Time.deltaTime;
            if (moveCounter <= 0)
            {
                waitCounter = Random.Range(0, 4);
                isMoving = false;
                enemyBody.velocity = Vector2.zero;
            }
        }
	}

    //stop moving and reset waitCounter when enemy bumps into anything
    void OnCollisionEnter2D(Collision2D coll)
    {
        isMoving = false;
        waitCounter = waitTime;
    }

    //on collision, stop, wait, and turn around 
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4); //0 = up, 1 = down, 2 = right, 3 = left

    }
}
