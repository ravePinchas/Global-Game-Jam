using System.Diagnostics;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed; // adjust the speed of the enemy
    public float damage;

    public float bulletSpeed = 7f;

    private Transform playerTransform;
    private Vector2 targetPosition;
    public Enemy enemyPrefab;
    
    public Enemy enemyInstance;
    private SpriteRenderer spriteRenderer;

    
    public GameObject xp;
    public GameObject bullet;


    private bool canShoot = true;

    public bool isShooter = false;
    public bool isGiant = false;
    public bool isNormal = false;

    Stopwatch stopwatch = new Stopwatch();
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyInstance.sprite;
        if (isGiant)
        {
            speed = 3f;
            damage = 15f;
            enemyInstance.hp = 150;
        }
        if (isNormal)
        {
            speed = 5f;
            damage = 10f;
            enemyInstance.hp = 100;
        }
        if (isShooter)
        {
            speed = 5f;
            damage = 15f;
            enemyInstance.hp = 70;
        }
    }


    
    private void Update()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        // calculate a grid-based target position for each enemy
        float x = playerTransform.position.x + (Mathf.Round(transform.position.x - playerTransform.position.x) * 0.6f);
        float y = playerTransform.position.y + (Mathf.Round(transform.position.y - playerTransform.position.y) * 0.6f);
        targetPosition = new Vector2(x, y);

        
        if(!isShooter)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if (isShooter)
        {
            if (Vector2.Distance(transform.position, targetPosition) < 2f && canShoot)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                //bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, targetPosition, bulletSpeed * Time.deltaTime);
                canShoot = false;
                Invoke("ChangeCanShoot", 3f);
            }
            else if(canShoot)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

    private void ChangeCanShoot()
    {
        canShoot = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reduceHealth();
        }
    }

    void reduceHealth()
    {
        //do for X Seconds

        stopwatch.Start();
        if (stopwatch.ElapsedMilliseconds > 1000)
        {
            stopwatch.Reset();
            FindObjectOfType<PlayerMovment>().health -= damage;
        }
    }
}
