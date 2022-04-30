using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    enum BossStates{charge, phase1, phase2, dead}

    BossStates curState;
    public GameObject minion;
    public Transform[] spawnPos;
    public EnemyController ec;
    int hp = 100;
    void Start()
    {
        curState = BossStates.phase1;
        ec = GetComponent<EnemyController>();
        ec.BossUp();
    }

    // Update is called once per frame
    void Update()
    {
        StateChecker();
        CheckHp();
    }
    public void StateChecker()
    {
        switch(curState)
        {
            case BossStates.charge:
            break;
            case BossStates.phase1:
            BossP1();
            break;
            case BossStates.phase2:
            BossP2();
            break;
            case BossStates.dead:
            break;
            default:
            break;
        }
    }
    
    IEnumerator ReCharge()
    {
        curState = BossStates.charge;
        Debug.Log("Recharging");
        yield return new WaitForSeconds(4f);
        if(ec.GetHp() > 50)
        {
            curState = BossStates.phase1;
        }
        else if(ec.GetHp() <= 0)
        {
            curState = BossStates.dead;
        }
        else
        {
            curState = BossStates.phase2;
        }
    }

    public void BossP1()
    {
        Instantiate(minion, spawnPos[0].position, Quaternion.identity);
        StartCoroutine(ReCharge());
    }
    public void BossP2()
    {
        Instantiate(minion, spawnPos[0].position, Quaternion.identity);
        Instantiate(minion, spawnPos[1].position, Quaternion.identity);
        StartCoroutine(ReCharge());
    }
    public void CheckHp()
    {
        
        if(ec.GetHp() <= 0)
        {
            curState = BossStates.dead;
        }
    }

    
}
