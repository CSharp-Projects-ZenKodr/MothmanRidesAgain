using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertTracker : MonoBehaviour
{
    public Text alertTracker;
    public EnemyAlert alert;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alertTracker.text = (int)alert.detectionLevel + "/100";
    }
}
