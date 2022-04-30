using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] rooms;
    int rnd;
    void Start()
    {
        Invoke("FindBossRoom", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindBossRoom()
    {
        rooms = GameObject.FindGameObjectsWithTag("RoomStuffer");
        rnd = Random.Range(0, rooms.Length);
        rooms[rnd].gameObject.GetComponent<RoomStuffer>().BossUp();
    }
}
