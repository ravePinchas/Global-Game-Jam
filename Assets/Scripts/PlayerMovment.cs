using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 5f;
    Vector3 vec;
    private Transform playerTransform;

    public RandomSound footSteps;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
             playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vec = transform.localPosition;
        vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        vec.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        vec.z = 0;
        transform.localPosition = vec;



        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - playerTransform.position.x,
            mousePosition.y - playerTransform.position.y
        );

        playerTransform.up = direction;

        if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            footSteps.PlayRandomSound();
        }
    }
}
