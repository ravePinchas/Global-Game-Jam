using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Transform playerTransform;
    private Vector2 targetPosition;
    public float bulletSpeed = 15f;
    public float damage = 15f;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        float x = playerTransform.position.x + (Mathf.Round(transform.position.x - playerTransform.position.x) * 0.6f);
        float y = playerTransform.position.y + (Mathf.Round(transform.position.y - playerTransform.position.y) * 0.6f);
        
        targetPosition = new Vector2(x, y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, bulletSpeed * Time.deltaTime);

        Vector2 tempPos = transform.position;
        
        Vector2 bulletDirection = targetPosition - tempPos;
        bulletDirection.Normalize();
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = bulletDirection * bulletSpeed;

        //rb.AddForce(bulletDirection * bulletSpeed - rb.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovment>().health -= damage;
            Destroy(gameObject);
        }
    }
}
