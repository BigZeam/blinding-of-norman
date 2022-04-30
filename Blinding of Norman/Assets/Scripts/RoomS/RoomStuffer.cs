using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStuffer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] positions;
    public GameObject chest, enemy, key, light, complete;
    public GameObject doorBlocks;
    GameObject myKey;
    public int enemies2Spawn, lights2Spawn, rnd;

    void Start()
    {
        //SpawnThings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        doorBlocks.SetActive(false);
        complete.SetActive(true);
    }
    public void SpawnThings()
    {
        doorBlocks.SetActive(true);
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
        rnd = (int)Random.Range(0, positions.Length);
        myKey = Instantiate(key, positions[rnd].position, Quaternion.identity);
        myKey.gameObject.GetComponent<KeyScript>().SetStuffer(this);
    }
}
