using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public RoomStuffer rs;
    bool spawned = false;

    public void EnteredRoom()
    {
        if(!spawned)
            rs.SpawnThings();

        spawned = true;
    }
}
