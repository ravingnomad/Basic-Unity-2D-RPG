using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (GameObject.Find("Dialogue Box").GetComponent<Animator>().GetBool("IsOpen") == true)
        {
            FindObjectOfType<PlayerShoot>().hasGun = true;
            FindObjectOfType<DestroyManager>().AddToList(this.name);
            Destroy(gameObject);
        }
    }
}
