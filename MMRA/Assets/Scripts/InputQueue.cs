using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputQueue : MonoBehaviour
{
    private int[] values;
    private List<KeyPress> inputArray;

    public float timeActive;

    void Awake()
    {
        values = (int[])System.Enum.GetValues(typeof(KeyCode));
        inputArray = new List<KeyPress>();
    }

    void Update()
    {
        for (int i = 0; i < inputArray.Count; i++)
        {
            // add time to each key in the list
            inputArray[i].increaseTime(Time.deltaTime);

            // remove inactive keys
            if (!inputArray[i].isActive(timeActive))
            {
                inputArray.RemoveAt(i);
            }
        }
        // add all pressed keys
        for (int i = 0; i < values.Length; i++)
        {
            if (Input.GetKeyDown((KeyCode)values[i]))
            {
                inputArray.Add(new KeyPress((KeyCode)values[i]));
            }
        }
    }

    // returns times key is found in inputArray
    public int getKey(KeyCode key)
    {
        int count = 0;
        foreach (KeyPress keyPress in inputArray)
            if (keyPress.Equals(key))
                count++;
        return count;
    }

    public void emptyQueue()
    {
        inputArray.Clear();
    }

}

public class KeyPress
{
    private KeyCode key;
    private float deltaTime;

    public KeyPress(KeyCode pressed)
    {
        key = pressed;
        deltaTime = 0;
    }

    public KeyCode getKey()
    {
        return key;
    }

    public bool isActive(float activeTime)
    {
        return deltaTime <= activeTime;
    }

    public void increaseTime(float time)
    {
        deltaTime += time;
    }

    public virtual bool Equals(KeyCode key)
    {
        return key == getKey();
    }
}