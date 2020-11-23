using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletSpeed;
    public string bulletType; //additional properties depending on bullet
    public int damage;
    public int typeDamage; //additional damage if certain bullet types

	// Use this for initialization
	void Start () {
		
	}


    //Destroy on collision with anything
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player")
            Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
