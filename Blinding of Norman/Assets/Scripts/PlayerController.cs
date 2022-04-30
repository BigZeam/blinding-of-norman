using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //variables
    public float speed;
    public bool inTheLight = false;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public Transform[] positions;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage = 5;
    public int hitpoints = 6;
    public int level = 1, curXP;

    //ui vars
    public Text levelText, healthText, xpText;
    public GameObject gameOverPanel;

    private float timeBtwAttack;
    private int maxHP;

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
        ShowUI();
        CheckLevels();
    }


    //General Methods
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0) * Time.deltaTime;
    }
    void CheckLevels()
    {
        maxHP = 10 * level;
        if(curXP > (level * level) + 10)
        {
            level++;
            curXP = 0;
        }

        if(hitpoints <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
    void CollectXP(int xp)
    {
        curXP += xp;
    }
    void Attack()
    {
        damage = level * 5;
        if(timeBtwAttack <=0)
        {
            if(Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K)||Input.GetKey(KeyCode.J) && inTheLight)
            {
                //Debug.Log("Trying to attack");
                SetAttackPos();
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
    public void SetAttackPos()
    {
        if(Input.GetKey(KeyCode.I))
        {
            attackPos = positions[0];
        }
        if(Input.GetKey(KeyCode.L))
        {
            attackPos = positions[1];
        }
        if(Input.GetKey(KeyCode.K))
        {
            attackPos = positions[2];
        }
        if(Input.GetKey(KeyCode.J))
        {
            attackPos = positions[3];
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
       if(col.gameObject.tag == "EnterRoom")
       {
           col.gameObject.GetComponent<RoomEnter>().EnteredRoom();
       }
       if(col.gameObject.tag == "Key")
       {
           col.gameObject.GetComponent<KeyScript>().MajorKeyAlert();
       }
       if(col.gameObject.tag == "XP")
       {
            curXP += col.gameObject.GetComponent<ExperienceOrb>().GetValue();
            Destroy(col.gameObject);
       }
       if(col.gameObject.tag == "Health")
       {
            hitpoints += col.gameObject.GetComponent<Health>().GetValue();
            if(hitpoints > maxHP)
                hitpoints = maxHP;
            Destroy(col.gameObject);
       }
       if(col.gameObject.tag == "Chest")
       {
           col.gameObject.GetComponent<Chest>().Open();
       }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Light")
       {
           SetLight(false);
       }
    }

    public void ShowUI()
    {
        levelText.text = "Level " + level;
        healthText.text = "Health " + hitpoints;
        xpText.text = "XP " + curXP;
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
