using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField]
    protected float debugDrawRadius = 1.0F;
	// Use this for initialization
	public virtual void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);


	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        //Accesses individual npc's public UpdateWaypoint method
        if (other.gameObject.tag == "NPC")
        {
            other.GetComponent<NPC>().UpdateWaypoints();
        }
    }
}
