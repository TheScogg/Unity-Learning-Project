using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
    private GameObject[] waypoints;

    private GameObject currentWaypoint;
    private GameObject nextWaypoint;

    Vector3 _destination;

    private class Attributes
    {
        private float _hSV;

        public Attributes()
        {
            
        }

        public int Rating { get; set; }
        public int Poo { get; set; }


        public float HSV
        {
            get
            {
                
                return HSV;
            }
            set
            {
                // 0 to 100 from .7 to 1
                // (
                // Color.HSVToRGB(Random.Range(.7f, 1f), 1f, 1f)d
                HSV = value;
            }
        }




    }

    // Use this for initialization
    void Start () {
        Initialize();
        
    }

    // Update is called once per frame
    void Update () {
	}

    private void Initialize() {
        SetAttributes();
        GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(Random.Range(.7f, 1f), 1f, 1f));
        InitWaypoints();
    }

    private void SetAttributes() {
        Attributes npc = new Attributes();
        
    }

    private void InitWaypoints() {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        //nextWaypoint = waypoints[Random.Range(0, waypoints.Length)];

        //while (nextWaypoint == currentWaypoint) {
        //    nextWaypoint = waypoints[Random.Range(0, waypoints.Length)];
        //}

        do
        {
            nextWaypoint = waypoints[Random.Range(0, waypoints.Length)];
        } while (nextWaypoint == currentWaypoint);

        

        _destination = nextWaypoint.transform.position;

        GetComponent<NavMeshAgent>().SetDestination(_destination);
        
        if (nextWaypoint == currentWaypoint) { print("AHAHAHAHA"); }

        currentWaypoint = nextWaypoint;
    }

    public void UpdateWaypoints() {
        InitWaypoints();
    }

    //public List<string> GetStats() {

    //}
}
