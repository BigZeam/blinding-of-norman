using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum Behavior {Still, Follow, Stunned};

    GameObject player;
    Behavior curBehavior;
    Vector2 movement;
    Rigidbody2D rb;
    bool canAttack = false;
    float speed = 3;
    public int hitpoints = 10, damage = 2;
    float starttimeBtwStun = 2f, timeBtwStun;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        curBehavior = Behavior.Still;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAction();
        DeadCheck();
    }
    private void CalculateAction()
    {
        if(player.gameObject.GetComponent<PlayerController>().GetLight() && canAttack)
        {
            curBehavior = Behavior.Follow;
        }
        /*else 
        {
            curBehavior = Behavior.Still;
        }
        */
        switch(curBehavior)
        {
            case Behavior.Still:
            break;
            case Behavior.Follow:
            speed = 3;
            FollowPlayer();
            timeBtwStun-=Time.deltaTime;
            break;
            case Behavior.Stunned:
            speed = 0;
            StartCoroutine(Stun());
            break;
            default:
            break;
        }
    }
    void DeadCheck()
    {
        if(hitpoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FollowPlayer()
    {
        Vector3 direction = player.gameObject.GetComponent<Transform>().position - transform.position;
        direction.Normalize();
        movement = direction;

        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        hitpoints-=damage;
        Debug.Log("Hit");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            curBehavior = Behavior.Stunned;
            //timeBtwStun = starttimeBtwStun;
        }
    }

    //setters
    public void SetAttack(bool b)
    {
        canAttack = b;
    }

    //Coroutine
    IEnumerator Stun()
    {
        Debug.Log("stunned");
        yield return new WaitForSeconds(2f);
        curBehavior = Behavior.Follow;
    }


}
