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

        // If bullet hits anything other than the Player or another bullet...
        if (objectHit.gameObject.name != "Body" || objectHit.gameObject.name.Contains("Bullet") ) {
            gameObject.SetActive(false);

            for (int i = 0; i <= 10; i++)
            {
                GameObject bulletFragment = ObjectPooler.SharedInstance.GetPooledObject("ProjectileFragment");
                bulletFragment.transform.position = transform.position;
                bulletFragment.SetActive(true);
                bulletFragment.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            }
        }

    }
}
