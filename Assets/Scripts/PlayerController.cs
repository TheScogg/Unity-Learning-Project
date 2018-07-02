using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Public Variables
    public int speed = 500;
    Ray camRay;
    Ray gunRay;
    public GameObject plane;
    public Vector3 playerToMouse;
    public RaycastHit hit;

    Vector3 movement;

    private RaycastHit gunHit;
    RaycastHit[] hits;

    // Component Variables
    Rigidbody rb;



	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // WASD MOVEMENT
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(horizontal, 0f, vertical).normalized;
        rb.AddForce(movement * speed * Time.deltaTime);
        // MOUSELOOK ROTATION
        //Vector3 positionOnScreen = Camera.main.ScreenToWorldPoint(transform.position);
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
        playerToMouse = hit.point - transform.position;
        // Ensure the vector is entirely along the floor plane.
        playerToMouse.y = 0f;
        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.


        if (movement != Vector3.zero)
        {  }

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        rb.MoveRotation(newRotation);

        
        // Set the player's rotation to this new rotation.

        if (Physics.Raycast(camRay, out hit) && Input.GetMouseButton(1)) {

            gunRay = new Ray(transform.position, new Vector3(playerToMouse.x, playerToMouse.y, playerToMouse.z));

            if (Physics.Raycast(gunRay, out gunHit)) {
                print(gunHit.collider.tag);
                if (gunHit.collider.tag == "NPC") 
                {
                    gunHit.collider.GetComponent<Rigidbody>().AddForce(playerToMouse * 10);
                }
            }
        }


    }

    void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }


}
