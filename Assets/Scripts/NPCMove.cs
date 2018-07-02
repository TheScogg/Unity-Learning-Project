using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour {
    public Transform _destination;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.Log("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else {
            SetDestination();
        }

	}

    private void SetDestination() {
        //if (_destination != null) {
        //    Vector3 targetVector = _destination.transform.position;
        //    _navMeshAgent.SetDestination(targetVector);
        //}

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject item in waypoints) {
            print(item.name);
        }

        int number = Random.Range(0, 4);
        print(waypoints[number].gameObject.name);
        _navMeshAgent.SetDestination(waypoints[number].transform.position);
    }

	// Update is called once per frame
	void Update () {
        //SetDestination();
    }
}
