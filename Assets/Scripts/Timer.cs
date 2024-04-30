using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objectToTeleport = null;
    public Vector3 destination = new Vector3 (0, 0, 0);

    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    [SerializeField]

    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Level Complete!");
                timeRemaining = 0;  
                timerIsRunning = false;
                //Move object
                objectToTeleport.transform.position = destination;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.Floor(timeToDisplay / 60);
        float seconds = Mathf.Floor(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
