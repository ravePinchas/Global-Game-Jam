using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = PlayerMovment.playerInstance.transform;




    }

    // Update is called once per frame
    void Update()
    {

            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
      

    }
}
