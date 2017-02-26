using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.transform.position;

    }
}
