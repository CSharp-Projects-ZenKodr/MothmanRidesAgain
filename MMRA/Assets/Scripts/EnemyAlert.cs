using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{

    public double detectionLevel = 0;
    public bool detected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(detected == true)
        {
            increaseDetectionLevel();
        }
        if(detectionLevel < 0)
        {
            detectionLevel = 0;
        }
        else if(detectionLevel < 33)
        {

        }
        else if(detectionLevel >= 33 && detectionLevel < 66)
        {

        }
        else if(detectionLevel >= 66)
        {

        }
        else if(detectionLevel > 100)
        {
            detectionLevel = 100;
        }
    }

   public void increaseDetectionLevel()
    {
        if(detectionLevel < 100)
        {

            detectionLevel += 0.1;

        }
    }
}
