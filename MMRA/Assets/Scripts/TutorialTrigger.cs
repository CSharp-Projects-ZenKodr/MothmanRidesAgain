using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public string TutorialMessage;

    private LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player enters tutorial's trigger box
        if (collision.gameObject.tag == "Player")
        {
            // call method in LevelManager to pause game & display TutorialMessage
            levelManager.TutorialMessage(TutorialMessage);

            // disable this trigger
            gameObject.SetActive(false);
        }
    }
}
