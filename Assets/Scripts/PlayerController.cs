﻿using System.Collections;
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
    public float gunTimer = 2f;
    public int bulletSpeed = 1000;

    Vector3 movement;
    private RaycastHit gunHit;

    // Component Variables
    Rigidbody rb;

	void Start () {
        Initialize();
	}
	
	void FixedUpdate () {
        gunTimer -= Time.deltaTime;

        // WASD MOVEMENT
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(horizontal, 0f, vertical).normalized;
        rb.AddForce(movement * speed * Time.deltaTime);

        if (Physics.Raycast(camRay, out hit) && Input.GetMouseButton(1))
        {
            gunRay = new Ray(transform.position, playerToMouse);

            if (Physics.Raycast(gunRay, out gunHit))
            {
                print(gunHit.collider.tag);
                if (gunHit.collider.tag == "NPC")
                {
                    gunHit.collider.GetComponent<Rigidbody>().AddForce(playerToMouse.normalized * 100);
                }
            }
        }

        // MOUSELOOK ROTATION
        //Vector3 positionOnScreen = Camera.main.ScreenToWorldPoint(transform.position);
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
        playerToMouse = hit.point - transform.position;


        // Ensure the vector is entirely along the floor plane.
        playerToMouse.y = 0f;
        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        // Set the player's rotation to this new rotation.
        rb.MoveRotation(newRotation);
        


        if (Input.GetMouseButton(0)) {
            if (gunTimer < 0) {
                SpawnBullet();
                gunTimer = .2f;
            }
        }

    }

    void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void SpawnBullet() {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Projectile");
        bullet.transform.position = transform.Find("Gun").transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed * Time.deltaTime;
    }


}
