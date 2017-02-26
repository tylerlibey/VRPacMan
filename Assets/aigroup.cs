using UnityEngine;
using System.Collections;

public class aigroup : MonoBehaviour {

    public GameObject[] ghosts;
    private Vector3[] starting;


    private float delayTime = 5;
    private float last = 0;
    private int active = 0;

	// Use this for initialization
	void Start () {
        starting = new Vector3[ghosts.Length];
        for(int ii = 0; ii < ghosts.Length; ii++)
        {
            starting[ii] = ghosts[ii].transform.position;
            ghosts[ii].GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > last + delayTime)
        {
            activate();
            last = Time.time;
        }
	}
    private void activate()
    {
        if (active < ghosts.Length) {
            ghosts[active].GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 20;
            active++;
        }
    }

    public void resetGhosts()
    {
        print("resetting");
        for (int ii = 0; ii < ghosts.Length; ii++)
        {
            
            ghosts[ii].GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
            ghosts[ii].GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(starting[ii]);

        }
        active = 0;
        last = Time.time;
    }
}
