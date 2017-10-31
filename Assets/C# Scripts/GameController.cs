using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static int iHealth;
    public static int iScore;
    public static int iCantEnemies;
    public static int iCantClouds;
    public static bool bPlayerIsAttacking;
    public static bool bEnd;

    public GameObject[] pause;
    public GameObject[] endGame;

    public Text txtTime;
    public Text txtScore;
    public Text txtHealt;

    static System.Random randR;

    int iIniTime;
    int iTime;
    bool bPause;

    // Use this for initialization
    void Start () {
        iHealth = 100;
        iScore = 0;
        iCantEnemies = 0;
        bPause = false;

        for (int i = 0; i < pause.Length; i++)
        {
            pause[i].SetActive(false);
        }
        for (int i = 0; i < endGame.Length; i++)
        {
            endGame[i].SetActive(false);
        }

        randR = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
        if (! bEnd)
        {
            UpdateTime();
            UpdateScore();
            UpdateHealth();
            UpdatePause();
        }
        else
        {
            EndGame();
        }
    }

    public static float GetRandom(int iNum)
    {
        return randR.Next(0, iNum);
    }

    void UpdatePause()
    {
        if (Input.GetKey(KeyCode.P))
        {
            bPause = ! bPause;
            System.Threading.Thread.Sleep(250);
        }


        if (bPause)
        {
            Time.timeScale = 0;
            for (int i = 0; i < pause.Length; i++)
            {
                pause[i].SetActive(true);
            }

            if (Input.GetKey(KeyCode.M))
            {
                ChangeScene.ButtonChangeScene("Menu");
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Application.Quit();
            }
        }
        else
        {
            Time.timeScale = 1;
            for(int i = 0; i < pause.Length; i++)
            {
                pause[i].SetActive(false);
            }
        }
    }

    void UpdateTime()
    {
        int iTimeGone = (int)(Time.time - iIniTime);
        int iSec = iTimeGone % 60;
        int iMin = iTimeGone / 60;
        string sSec = iSec.ToString();
        string sMin = iMin.ToString();

        if (iSec < 10)
        {
            sSec = "0" + sSec;
        }
        if (iMin < 10)
        {
            sMin = "0" + sMin;
        }

        txtTime.text = "Time: " + sMin + ":" + sSec;
    }

    void UpdateScore()
    {
        txtScore.text = "Score: " + iScore.ToString();
    }

    void UpdateHealth()
    {
        bEnd = iHealth <= 0;
        txtHealt.text = "Health: " + iHealth.ToString();
    }

    void EndGame()
    {
        for (int i = 0; i < endGame.Length; i++)
        {
            endGame[i].SetActive(true);
        }

        if (Input.GetKey(KeyCode.M))
        {
            ChangeScene.ButtonChangeScene("Menu");
        }
    }
}