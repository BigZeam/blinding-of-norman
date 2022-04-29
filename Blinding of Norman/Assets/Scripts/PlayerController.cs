using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    public float speed;
    public bool inTheLight = false;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage = 5;
    public int hitpoints = 6;

    private float timeBtwAttack;
    

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }


    //General Methods
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0) * Time.deltaTime;
    }
    void Attack()
    {
        if(timeBtwAttack <=0)
        {
            if(Input.GetKey(KeyCode.L) && inTheLight)
            {
                //Debug.Log("Trying to attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else 
        {
            timeBtwAttack -=Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        hitpoints-=damage;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    private void OnTriggerEnter2D(Collider2D col) {
       if(col.gameObject.tag == "Light")
       {
           SetLight(true);
       }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Light")
       {
           SetLight(false);
       }
    }

    //Setters
    public void SetLight(bool light)
    {
        inTheLight = light;
    }


    //Getters
    public bool GetLight()
    {
        return inTheLight;
    }
}
