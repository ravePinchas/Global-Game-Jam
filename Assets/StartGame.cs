using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void StartGameCallback()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.levelNamePrefix + 1);
    }
}
