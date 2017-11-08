using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int moveSpeed = 5;

    private Rigidbody2D MCBody;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private static bool playerExists;

	void Start () {
        anim = GetComponent<Animator>();
        MCBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

        playerMoving = false;
        
		if (Input.GetAxisRaw("Horizontal") >= 0.5 || Input.GetAxisRaw("Horizontal") <= -0.5)
        {
            MCBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, MCBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") >= 0.5 || Input.GetAxisRaw("Vertical") <= -0.5)
        {
            MCBody.velocity = new Vector2(MCBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }


        //if player doesn't input directions, set velocity in direction(s) to 0
        if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
        {
            MCBody.velocity = new Vector2(0f, MCBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5)
        {
            MCBody.velocity = new Vector2(MCBody.velocity.x, 0f);
        }


        anim.SetBool("Player Moving", playerMoving);
        anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Move Y", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Last Move X", lastMove.x);
        anim.SetFloat("Last Move Y", lastMove.y);
    }

    //returns the player's last move (i.e. direction they are facing) for attacking script
    public Vector2 GetLastMove()
    {
        return lastMove;
    }
}
