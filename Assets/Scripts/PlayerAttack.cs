using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject axe;
    public bool isAttack = false;




    private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;


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

            if (Input.GetMouseButtonDown(1))
            {
                //anim.SetBool("Is_attacking", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++)
                {
                    Instantiate(damage[i].gameObject.GetComponent<EnemyBehavior>().xp, damage[i].gameObject.transform.position, Quaternion.identity);
                    Destroy(damage[i].gameObject);
                }
            }
            
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }





}
