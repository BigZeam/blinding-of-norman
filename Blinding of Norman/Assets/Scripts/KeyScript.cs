using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update\
    RoomStuffer rs;

    //collecting the key
    public void MajorKeyAlert()
    {
        rs.Unlock();
        Destroy(this.gameObject);
    }

    public void SetStuffer(RoomStuffer r)
    {
        rs = r;
    }
}
