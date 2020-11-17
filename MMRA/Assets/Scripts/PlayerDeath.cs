using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath instance;
    public bool crash = false;

    private void Awake()
    {
        instance = this;
    }

    
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            crash = true;
            //Makes Unity wait for the death animation to play before respawning
            yield return new WaitForSecondsRealtime(1f);
            Destroy(gameObject);
            //LevelManager.instance.transform.position = LevelManager.instance.respawnPoint.transform.position;
            LevelManager.instance.Respawn();
        }
    }
}
