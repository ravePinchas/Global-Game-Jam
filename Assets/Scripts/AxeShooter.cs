using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeShooter : MonoBehaviour
{
    private Vector3 startPosition;
    Rigidbody2D rb;
    public float speed = 7f;
    bool moveBack = false;
    bool startAxe = true;
    GameObject player;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void Update()
    {
        player = GameObject.Find("Player");
        if (startAxe)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            direction.z = 0;
            direction.Normalize();
            rb.velocity = direction * speed;
            startAxe = false;
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 5f || moveBack)
        {
            //move the object toward startPosition
            //Vector3 backPosition = Camera.main.ScreenToWorldPoint(startPosition);
            Vector3 direction2 = player.transform.position - transform.position;
            direction2.z = 0f;
            direction2.Normalize();
            rb.velocity = direction2 * speed;
            moveBack = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (moveBack && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.GetComponent<PlayerMovment>().isAttack = false;
        }
    }
}
