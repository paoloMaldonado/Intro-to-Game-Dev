using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundStartTime;
    int waitTime;
    bool roundStarted;

    void Start()
    {
        print("Press the space bar once you think the alloted time is up");
        Invoke("SetNewRandomTime", 3);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            roundStarted = false;
            float playerWaitTime = Time.time - roundStartTime;
            float error = Mathf.Abs(waitTime - playerWaitTime);

            string message = "";
            if(error < 0.15f)
            {
                message = "Outstanding";
            }
            else if(error < 0.75f)
            {
                message = "Exceeds expectations";
            }
            else if(error < 1.25f)
            {
                message = "Acceptable";
            }
            else if (error < 1.75f)
            {
                message = "Poor";
            }
            else
            {
                message = "Dreadful";
            }

            print("You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off. " + message);
            Invoke("SetNewRandomTime", 3);
        }
    }

    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;
        roundStarted = true;
        print(waitTime + " seconds");
    }

}
