using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject axe;
    public bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            
            Instantiate(axe, transform.position, Quaternion.identity);
            isAttack = true;
        }
        else if (Input.GetMouseButtonDown(1) && !isAttack)
        {
            
        }
    }
}
