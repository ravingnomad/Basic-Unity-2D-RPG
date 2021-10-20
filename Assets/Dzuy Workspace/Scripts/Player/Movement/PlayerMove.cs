using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int moveSpeed = 5;
    public string StartPoint;

    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private bool playerMoving;
    private Vector2 lastMoveDirection;
    public static bool Exists;

	void Start () {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        lastMoveDirection = new Vector2(0, -1);
        if (!Exists)
        {
           Exists = true;
           DontDestroyOnLoadManager.SetDontDestroy(this.gameObject);
       }

        else
        {
            Destroy(gameObject);
        }
	}
	

	void Update () {
        playerMoving = false;
        movePlayer();
        //if player doesn't input directions, set velocity in direction(s) to 0
        if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
        {
            playerRigidBody.velocity = new Vector2(0f, playerRigidBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0f);
        }
        setAnimationVariables();

    }

    private void movePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") >= 0.5 || Input.GetAxisRaw("Horizontal") <= -0.5)
        {
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidBody.velocity.y);
            playerMoving = true;
            lastMoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") >= 0.5 || Input.GetAxisRaw("Vertical") <= -0.5)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMoveDirection = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
    }


    private void setAnimationVariables()
    {
        animator.SetBool("Player Moving", playerMoving);
        animator.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Move Y", Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Last Move X", lastMoveDirection.x);
        animator.SetFloat("Last Move Y", lastMoveDirection.y);
    }
 
    public Vector2 GetLastMove()
    {
        return lastMoveDirection;
    }

    public bool moving()
    {
        return playerMoving;
    }
}
