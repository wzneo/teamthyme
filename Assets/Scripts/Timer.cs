﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    //public int cdMinutes;
    public int cdSeconds;

    private Text timerText;
    private float startTime;
    private bool startCd;

	// Use this for initialization
	void Start () {
        timerText = gameObject.GetComponent<Text>();
        timerText.text = "";
        startCd = false;
    }

    public void startTimer()
    {
        startTime = Time.time;
        startCd = true;
    }

    public void stopTimer()
    {
        timerText.text = "";
        startCd = false;
    }

    // Update is called once per frame
    void Update () {
        if (startCd)
        {
            float t = Time.time - startTime;
            string secondsLeft = Mathf.Max(0, cdSeconds - (int)t % 60).ToString();
            timerText.text = secondsLeft;

            if (secondsLeft == "0")
            {
                stopTimer();
                GameManager.restartLevel(false);
            }
        }
    }
}
