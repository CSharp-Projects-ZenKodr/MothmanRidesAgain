using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{
    public float levelTime = 180;
    private Text timeDisplay;
    private int min, sec;
    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = GetComponent<Text>();
    }

    private void Update()
    {
        min = (int) (levelTime / 60);
        sec = (int) (levelTime % 60);

        if (sec < 10)
            timeDisplay.text = (min + ":0" + sec);
        else
            timeDisplay.text = (min + ":" + sec);

        levelTime -= Time.deltaTime;
    }

}
