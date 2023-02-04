using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IMsgStageEnd
{
    [System.NonSerialized] public static string levelNamePrefix = "Level ";

    public bool advanceLevelCheatEnabled = true;
    public int maxLevelNumber = 7;


    GameTime timer;

    GameObject timerGameObject;
    GameObject uiCanvasGameObject;
    GameObject player;

    GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        MessagingSystem<IMsgStageEnd>.Subscribe(gameObject);
        MessagingSystem<IMsgGameEnd>.Subscribe(gameObject);
        MessagingSystem<IMsgPlayerDead>.Subscribe(gameObject);

        timer = GameTime.GetTimer();
        if (timer == null) Debug.LogError("Couldn't get the game timer");
        player = GameObject.Find("Player");
        PlayerMovment.playerInstance.gameObject.GetComponent<PlayerAttack>().isAttack = false;

        timerGameObject = GameTime.GetGameObject();
        DontDestroyOnLoad(timerGameObject);
        uiCanvasGameObject = GameObject.Find("UI Canvas");
        DontDestroyOnLoad(uiCanvasGameObject);

        DontDestroyOnLoad(gameObject);

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (advanceLevelCheatEnabled && Input.GetKeyDown(KeyCode.Alpha0))
        {
            AdvanceLevel();
        }
    }

    public void HandleMessage(System.Type msgType, object data)
    {
        if (msgType == typeof(IMsgStageEnd))
        {
            AdvanceLevel();
        }
        else if (msgType == typeof(IMsgGameEnd))
        {
            // #TODO: End game logic
        }
        else if (msgType == typeof(IMsgPlayerDead))
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void AdvanceLevel()
    {
        bool changeLevel = false;
        int levelNumber = 1;
        string currSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (currSceneName.StartsWith(levelNamePrefix))
        {
            string levelNumberString = currSceneName.Substring(levelNamePrefix.Length);
            levelNumber = int.Parse(levelNumberString);
            if (levelNumber < maxLevelNumber)
            {
                changeLevel = true;
                ++levelNumber;
                timer.ResetStageTimer();
            }
            else
            {
                MessagingSystem<IMsgGameEnd>.SendMessage();
            }
        }
        if (currSceneName.Equals("SampleScene"))
        {
            changeLevel = true;
        }
        if (changeLevel)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelNamePrefix + levelNumber);
        }
    }

    public void HandlePlayAgain()
    {
        Destroy(timerGameObject);
        Destroy(uiCanvasGameObject);
        Destroy(player);
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelNamePrefix + 1);
    }

    public void HandleQuit()
    {
        Application.Quit();
    }
}
