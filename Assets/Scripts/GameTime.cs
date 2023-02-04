using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public bool showTimerUI = true;
    public float stageTimeInMinutes = 5.0f; // Each round is 5 minutes

    // Read only attributes (only display them in the Unity editor for debugging purposes)
    public bool gameStarted = false;
   public float gameStartTime;
    public float gameTimer;
    public float stageStartTime;
    public float stageTimer;
    public float stageEndTimer = 5.0f * 60.0f;

    GameObject timerUI = null;
    TextMeshProUGUI timerUIText = null;

    // Start is called before the first frame update
    void Start()
    {
        // Should this be called by after clicking "Start" from a menu or something instead?
        GameStart();

        timerUI = GameObject.Find("TimerUI");
        int iChildren = timerUI.transform.childCount;
        //GameObject timerUITextGameObject = timerUI.transform.GetChild(0).gameObject;
        //timerUIText = timerUITextGameObject.GetComponent<TextMeshProUGUI>();
        timerUIText = timerUI.GetComponentInChildren<TextMeshProUGUI>();
        timerUI.SetActive(false);
        stageEndTimer = stageTimeInMinutes * 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            float currTime = Time.time;
            gameTimer = currTime - gameStartTime;
            stageTimer = currTime - stageStartTime;
            // #TODO: Update timer UI
            if (showTimerUI && timerUI != null)
            {
                timerUI.SetActive(true);
                float stageTimeMinutes = stageTimer / 60.0f;
                float stageTimeSecs = stageTimer % 60.0f;
                timerUIText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(stageTimeMinutes), Mathf.FloorToInt(stageTimeSecs));
            }
            if (stageTimer >= stageEndTimer)
            {
                MessagingSystem<IMsgStageEnd>.SendMessage();
            }
        }
    }

    public void GameStart()
    {
        gameStartTime = Time.time;
        gameTimer = 0.0f;
        gameStarted = true;
        StageStart();
    }

    public void StageStart()
    {
        stageStartTime = Time.time;
        stageTimer = 0.0f;
    }

    public static GameTime GetTimer()
    {
        return GameObject.Find("Timer").GetComponent<GameTime>();
    }
}
