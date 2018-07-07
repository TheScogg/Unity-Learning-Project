using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    Vector3 offset;
    Vector3 rotationOffset;
    public GameObject player;

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 startRot;
    [SerializeField] Vector3 endPos;
    [SerializeField] Vector3 endRot;
    [SerializeField] int scrollSpeed = 10;

    float interpolationPercent;


    // Use this for initialization
    void Start() {

        Initialize();
    }

    void Initialize() {

        // If [SerializeField] starting position and rotation vectors are NOT empty, 
        // set transform position and rotation to Inspector entered values

        if (startPos != Vector3.zero)
        {
            transform.position = startPos;
        }

        if (startRot != Vector3.zero) {
            transform.rotation = Quaternion.Euler(startRot);
        }

        offset = transform.position - player.transform.position;


        startPos = transform.position;
        print(startPos);
    }

    // Update is called once per frame
    void Update() {
        transform.position = player.transform.position + offset;

        Zoom();
    }

    void Zoom() {
        float scrollAxis = Input.GetAxis("Mouse ScrollWheel");
        if (scrollAxis != 0) {
            interpolationPercent = Mathf.Clamp01(interpolationPercent + scrollAxis * Time.deltaTime * scrollSpeed);
            offset = (Utils.Lerp(startPos, endPos, interpolationPercent));
            transform.rotation = Quaternion.Euler(Utils.Lerp(startRot, endRot, interpolationPercent));
        }



    }

}
