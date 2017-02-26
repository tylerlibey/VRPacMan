using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dotPicker : MonoBehaviour {

    int score = 0;
    int lives = 3;
    public Text scoreText;
    public aigroup aicontroller;
    public GameObject player;
    private Vector3 starting;
    bool restarting = false;
    float restartTime = 1;
    bool gameover = false;

	// Use this for initialization
	void Start () {
        starting = player.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (restarting || gameover)
        {
            player.transform.position = starting;
            restartTime -= Time.deltaTime;
            if (restartTime <= 0)
            {
                restartTime = 0;
                restarting = false;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "prize")
        {
            score++;
            scoreText.text = "Score " + score + " Lives: " + lives;
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
        }
        if(other.tag == "ai")
        {
            aicontroller.resetGhosts();
            if (!restarting)
            {
                lives--;
                if (lives == 0)
                {
                    scoreText.text = "Game Over!  Score " + score;
                    gameover = true;
                }
                else if (lives > 0)
                {
                    scoreText.text = "Score " + score + " Lives: " + lives;
                    player.transform.position = starting;
                }
                restarting = true;
            }
        }
    }
}
