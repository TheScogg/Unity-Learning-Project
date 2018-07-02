using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    public GameObject friendly;
    public GameObject enemy;
    public GameObject npc;
    [SerializeField] int npcs = 20;
    


    // Use this for initialization
    void Start()
    {
        CreateNPC(npcs);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateNPC(int npcs)
    {
        for (int i = 0; i <= npcs; i++)
        {
            Instantiate(npc, new Vector3(GetRandomNumber(), 0, GetRandomNumber()), Quaternion.identity, gameObject.transform);            //foe.GetComponent<NPCMove>()._destination = _destination;

            //friend.GetComponent<NPCMove>()._destination = _destination;
        }
    }

    private int GetRandomNumber() {
        return Random.Range(-25, 25);
    }

    void MakeWaypointsList(int qty) {
        // Clear list to wipe from previous runs


    }
}
