using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IMsgStageEnd
{
    static string levelNamePrefix = "Level ";

    public bool advanceLevelCheatEnabled = true;
    public int maxLevelNumber = 7;

    GameTime timer;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        MessagingSystem<IMsgStageEnd>.Subscribe(gameObject);
        MessagingSystem<IMsgGameEnd>.Subscribe(gameObject);

        timer = GameTime.GetTimer();
        if (timer == null) Debug.LogError("Couldn't get the game timer");
        player = GameObject.Find("Player");
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
        if (msgType == typeof(IMsgGameEnd))
        {
            // #TODO: End game logic
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
}
