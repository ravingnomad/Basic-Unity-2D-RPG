using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {


    public int Health;
    public int InvincibleTime;

    private GameObject player;
    private PlayerAttack attackScript;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        attackScript = player.GetComponent<PlayerAttack>();
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player Weapon")
        {
            PlayerMelee playerWeapon = col.GetComponent<PlayerMelee>();
            Health -= playerWeapon.Damage;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
