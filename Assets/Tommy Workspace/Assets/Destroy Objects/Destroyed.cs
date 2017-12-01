using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour {

    public Destroyable item;

    private void Update()
    {
        if (item.health == 0)
        {
            FindObjectOfType<DestroyManager>().AddToList(this.name);
            Destroy(gameObject);
        }
    }
}
