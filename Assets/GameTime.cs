using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public bool gameStarted = false;
    public float gameStartTime;
    public float gameTimer;
    public float stageStartTime;
    public float stageTimer;
    public float stageEndTimer = 5.0f * 60.0f; // Each round is 5 minutes

    // Start is called before the first frame update
    void Start()
    {
        // Should this be called by after clicking "Start" from a menu or something instead?
        GameStart();
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
