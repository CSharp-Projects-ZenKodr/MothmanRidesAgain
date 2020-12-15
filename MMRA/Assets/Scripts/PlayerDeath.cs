using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath instance;
    public bool crash = false;

    private Animator animator;

    private void Awake()
    {
        instance = this;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            crash = true;
            //Makes Unity wait for the death animation to play before respawning
            animator.SetTrigger("isCrashed");
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Dead");
            LevelManager.instance.Respawn();
        }
    }
}
