using System.Diagnostics;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f; // adjust the speed of the enemy
    private Transform playerTransform;
    private Vector2 targetPosition;
    public Enemy enemyPrefab;
    
    public Enemy enemyInstance;
    private SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject xp;

    public bool isShooter = false;

    Stopwatch stopwatch = new Stopwatch();
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyInstance.sprite;
    }


    
    private void Update()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        // calculate a grid-based target position for each enemy
        float x = playerTransform.position.x + (Mathf.Round(transform.position.x - playerTransform.position.x) * 0.6f);
        float y = playerTransform.position.y + (Mathf.Round(transform.position.y - playerTransform.position.y) * 0.6f);
        targetPosition = new Vector2(x, y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (isShooter)
        {
            //check if distance between targetposition to transforposition is less then 5f

        }
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
            UnityEngine.Debug.Log("Player hit");
            stopwatch.Reset();
            FindObjectOfType<PlayerMovment>().health -= 10;
        }
    }
}
