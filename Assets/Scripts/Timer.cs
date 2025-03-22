using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class InspectionTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public Image TimerBox;
    public float time, TotalTime;
    public  bool TimeOut, timerIsRunning;

    public void Start()
    {
        StartCoundownTimer();
    }
    public void StartCoundownTimer()
    {
        timerIsRunning = true;
        time = 90;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;//Count Down
                TotalTime += Time.deltaTime;//Count Up
                DisplayTime(time);
            }
            else
            {
                timerIsRunning = false;
                TimeOut = true;
                StopCoundownTimer();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        //float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        string minutes = Mathf.Floor(time / 60).ToString("0");
        string seconds = (time % 60).ToString("00");
        Debug.Log($"{minutes}:{seconds}");
        if (float.Parse(minutes) >= 0)
        {
            //TimerText.text = "Time Left : " + minutes + " min " + seconds + " sec"; //+ ":" + fraction;
            TimerText.text = minutes + " : " + seconds;
        }
        //Debug.Log("Time taken " + Mathf.Floor(TotalTime / 60).ToString("0") + " min " + (TotalTime % 60).ToString("00") + " sec");
    }

    public void StopCoundownTimer()
    {
        //CancelInvoke(); //Canceling Timer Invoke
        timerIsRunning = false;
        PlayerPrefs.SetString("Result", "You Win");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Result");
        time = 90;
    }

  }
