using UnityEngine;

public class testScript : MonoBehaviour
{
    public float detectionDistance = 1f;
    public LayerMask detectionLayerMask;
    public int damage = 10;

    private void Update()
    {
        Vector2 direction = (Vector2)transform.forward;
        float angle = 90f;

        Vector2 origin = (Vector2)transform.position + direction.normalized * angle;
        Vector2 end = origin + direction.normalized * detectionDistance;

        Debug.DrawLine(origin, end, Color.green);

        RaycastHit2D hit = Physics2D.Linecast(origin, end, detectionLayerMask);
        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            
        }
    }
}
