using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceLevelCheat : MonoBehaviour
{
    static string levelNamePrefix = "Level ";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            bool changeLevel = false;
            int levelNumber = 1;
            string currSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            if (currSceneName.StartsWith(levelNamePrefix))
            {
                changeLevel = true;
                levelNumber = int.Parse(currSceneName.Substring(levelNamePrefix.Length));
            }
            if (currSceneName.Equals("SampleScene"))
            {
                changeLevel = true;
            }
            if (changeLevel)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + levelNumber);
            }
        }
    }
}
