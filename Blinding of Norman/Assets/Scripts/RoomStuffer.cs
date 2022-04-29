using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStuffer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] positions;
    GameObject chest, enemy, key;
    GameObject[] doorBlocks;
    void Start()
    {
        
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
}
