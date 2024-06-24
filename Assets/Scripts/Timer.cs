using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining, timeStart = 60;
    public int timeRamainingInt;
    public TMP_Text timer;

    private void Start()
    {
        timeRemaining = timeStart;
    }

    void Update()
    {
        if (timeRemaining > 1)
        {
            timeRemaining -= Time.deltaTime;
            timeRamainingInt = (int)timeRemaining;
            timer.text = "Осталось " + timeRamainingInt.ToString() + " сек";
            if (timeRemaining <= timeStart / 2)
            {
                timer.color = Color.yellow;
            }
            else if (timeRemaining > timeStart / 2)
            {
                timer.color = Color.red;
            }
        }
        else
        {
            timer.color = Color.green;
        }
    }
}
