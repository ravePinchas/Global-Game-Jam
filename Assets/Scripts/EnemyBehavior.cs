using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f; // adjust the speed of the enemy
    private Transform playerTransform;
    private Vector2 targetPosition;
    public Enemy enemy;

    private void Update()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        // calculate a grid-based target position for each enemy
        float x = playerTransform.position.x + (Mathf.Round(transform.position.x - playerTransform.position.x) * 0.6f);
        float y = playerTransform.position.y + (Mathf.Round(transform.position.y - playerTransform.position.y) * 0.6f);
        targetPosition = new Vector2(x, y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (enemy.hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}
