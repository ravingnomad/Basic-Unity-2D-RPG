using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyAxis : MonoBehaviour {

    public Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();  
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        print("true");
        if (coll.gameObject.tag == "Ground")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePosition;
        }
    }


	// Update is called once per frame
	void Update () {
        
	}
}
