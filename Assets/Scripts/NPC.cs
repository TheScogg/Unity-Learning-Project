using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
    private GameObject[] waypoints;

    private GameObject currentWaypoint;
    private GameObject nextWaypoint;

    Vector3 _destination;

    Attributes npc;
    Renderer render;

    private class Attributes
    {
        public int health = 5;
        private float rating;
        private float _hSV;

        public Attributes()
        {
            this.rating = Rating;
        }

        public int Poo { get; set; }
        public float HSV { get; set; }

        public float Rating
        {
            get
            {
                return rating;
            }

            set
            {
                rating = Random.Range(.7f, 1f);
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
        SetColor();
        InitWaypoints();

    }

    private void SetColor() {
        render = GetComponent<Renderer>();
        Color color = Color.HSVToRGB(Random.Range(.7f, 1f), 1f, 1f);
        render.material.SetColor("_Color", color);
    }
    
    private void SetAttributes() {
        npc = new Attributes();
        
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

    public void Hit()
    {
        
        npc.health--;
        if (npc.health <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}
