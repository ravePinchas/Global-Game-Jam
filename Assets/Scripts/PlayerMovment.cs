using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 5f;
    Vector3 vec;
    [SerializeField] GameObject axe;
    public bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vec = transform.localPosition;
        vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        vec.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        vec.z = 0;
        transform.localPosition = vec;

        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            Instantiate(axe, transform.localPosition, Quaternion.identity);
        }
    }
}
