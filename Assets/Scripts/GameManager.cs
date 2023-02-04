using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovment.playerInstance.gameObject.GetComponent<PlayerAttack>().isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
