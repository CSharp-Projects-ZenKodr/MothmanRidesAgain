using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    public double detectionLevel = 0;
    public double detectionIncrement;
    public bool detected = false;
    public LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detected == true)
        {
            detectionLevel += detectionIncrement;
        }

        if (detectionLevel >= 100)
        {
            Time.timeScale = 0;
            manager.failPanel.SetActive(true);
        }

    }
}
