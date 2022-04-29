using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStuffer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] positions;
    public GameObject chest, enemy, key, light;
    public GameObject[] doorBlocks;

    public int enemies2Spawn, lights2Spawn, rnd;

    void Start()
    {
        SpawnThings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        for(int i = 0; i < doorBlocks.Length; i++)
        {
            if(doorBlocks[i]!=null)
                Destroy(doorBlocks[i]);
        }
    }
    public void SpawnThings()
    {
        for(int i = enemies2Spawn; i >0; i--)
        {
            rnd = (int)Random.Range(0, positions.Length);
            Instantiate(enemy, positions[rnd].position, Quaternion.identity);
        }
        for(int i = lights2Spawn; i >0; i--)
        {
            rnd = (int)Random.Range(0, positions.Length);
            Instantiate(light, positions[rnd].position, Quaternion.identity);
        }
    }
}
