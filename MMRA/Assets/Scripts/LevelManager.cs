using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject player;

    public GameObject pausePanel;
    private bool paused = false;

    public GameObject clearPanel;
    private bool cleared;

    public GameObject failPanel;

    public GameObject tutorialMessagePanel;
    private bool tutorial = false;

    private static int score;
    // time is current time, timetobeat is total time allowed for a level
    private static float time;
    public float TimeToBeat = 120;

    public CinemachineVirtualCameraBase cam;

    private void Awake()
    {
        instance = this;
        cleared = false;

        time = TimeToBeat;
        Time.timeScale = 1; // needed for reloading stages

        score = 0;
    }

    public void Respawn()
    {
        Debug.Log("Respawn Called");

        //GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        //cam.Follow = player.transform;
        //// Respawning sometimes disables different components, this fixes it:
        //player.GetComponentInChildren<PlayerMovment>().enabled = true;
        //player.GetComponentInChildren<Animator>().enabled = true;
        //player.GetComponentInChildren<CircleCollider2D>().enabled = true;

        player.transform.position = respawnPoint.position;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        cam.Follow = player.transform;

        PlayerDeath.instance.crash = false;

        Debug.Log("Respawned");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();

        if (tutorial && Input.GetKeyDown(KeyCode.Return))
        {
            tutorial = false;

            Time.timeScale = 1;

            tutorialMessagePanel.SetActive(false);
        }

        if (GameObject.Find("TrickDisplay").GetComponent<Text>().text.Equals(""))
            GameObject.Find("TrickDisplayPanel").GetComponent<Image>().enabled = false;
        else
            GameObject.Find("TrickDisplayPanel").GetComponent<Image>().enabled = true;

        // if player finished the level
        if (cleared)
        {
            // slow time to a stop
            if (Time.timeScale > 0)
                Time.timeScale -= 2 * Time.deltaTime;
        }
        else
        {
            if (Time.timeScale != 1 && paused == false && failPanel.activeSelf == false && tutorial == false)
                Time.timeScale = 1;

            // advance time
            time = time - Time.deltaTime;
        }

        // time runs out
        if (time <= 0)
        {
            FailState();
        }
        
    }

    public void TogglePause()
    {
        if (!paused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void ClearStage()
    {
        cleared = true;

        // enable clear panel
        clearPanel.SetActive(true);

        // set text for score and time displays
        GameObject.Find("ClearTime").GetComponent<Text>().text = "Time Left = " + TimeTracker.GetTimeText(time);
        GameObject.Find("ClearScore").GetComponent<Text>().text = "Score = " + ScoreController.GetScoreText(score);
    }

    // public setter for score
    public void AddToScore(int bonus)
    {
        score += bonus;
    }

    // public getter for score
    public int GetScore()
    {
        return score;
    }

    // public getter for remaining time
    public float GetTime()
    {
        return time;
    }

    public void FailState()
    {
        Time.timeScale = 0;
        failPanel.SetActive(true);
    }

    // method that handles tutorial messages (used only in tutorial level)
    public void TutorialMessage(string message)
    {
        Debug.Log("made it");
        
        tutorial = true;

        Time.timeScale = 0;
        
        tutorialMessagePanel.SetActive(true);
        GameObject.Find("TutorialMessage").GetComponent<Text>().text = message;
    }
}