using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // player enters stage clear trigger
        if(other.CompareTag("Player"))
        {
            levelManager.ClearStage();
        }
    }
}
