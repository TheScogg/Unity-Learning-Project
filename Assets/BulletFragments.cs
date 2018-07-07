using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFragments : MonoBehaviour {
    public float duration = 5;

    // Use this for initialization
    void Start() {

    }

    private void Update()
    {
    }

    // Update is called once per frame
    void OnEnable() {
        Invoke("Kill", 2.5f);

    }

    void Kill() {
        gameObject.SetActive(false);
    }
}
