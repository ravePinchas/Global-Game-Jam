using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIinstance : MonoBehaviour
{
    public static UIinstance instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
