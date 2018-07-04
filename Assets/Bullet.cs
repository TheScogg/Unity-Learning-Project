using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    GameObject objectHit;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreLayerCollision(9,9);
        objectHit = collision.collider.gameObject;

        if (objectHit.gameObject.tag.Contains("NPC")) {
            objectHit.GetComponent<NPC>().Hit();
        }

        if (objectHit.gameObject.name != "Body" || objectHit.gameObject.name.Contains("Bullet") ) {
            //gameObject.SetActive(false);
            gameObject.SetActive(false);

        }

    }
}
