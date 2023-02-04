using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 5f;
    Vector3 vec;
    private Transform playerTransform;
    public float xp = 0f;
    public float health = 100f;
    public int level = 1;
    public float xpAmount = 1f;

    public bool isLevelUp = false;

    public RandomSound footSteps;

    SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
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

        //check if the player is going left
        if (Input.GetAxis("Horizontal") < 0)
        {
            sp.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            sp.flipX = true;
        }


        //playerTransform.up = direction;

        if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            footSteps.PlayRandomSound();
        }

        GameObject[] xps = GameObject.FindGameObjectsWithTag("Xp");

        foreach (GameObject xp in xps)
        {
            if (Vector3.Distance(transform.position, xp.transform.position) < 2f)
            {
                Destroy(xp);
                this.xp += 10 * xpAmount;
                if (this.xp >= 100)
                {
                    this.xp = 0;
                    level++;
                    isLevelUp = true;
                    xpAmount *= 0.8f;
                    //TODO level up
                }
            }
        }
    }
}
