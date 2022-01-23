using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class COuntingstuff : MonoBehaviour
{
    public Text counterText;
    public bool timeCounter = false;
    public double seconds, minutes;
    private double startTime;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;  
    }

    public void startTimer()
    {
        timeCounter = true;
        startTime = Time.realtimeSinceStartupAsDouble;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter)
        {
            seconds = (int)((Time.realtimeSinceStartupAsDouble - startTime) % 60f);
            counterText.text = "Seconds" + ":" + seconds.ToString("00");
        }
        if ((seconds == 10) && (timeCounter == true))
        {
            timeCounter = false;
            GameObject playObject = GameObject.Find("Player");
            PlayerController controller = GameObject.Find("Player").GetComponent<PlayerController>();
            controller.CheckWin(2);
        }
    }

    
    public void endGame()
    {
        timeCounter = false;

    }
}
