using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    // Start is called before the first frame update
    Transform myPos;
    int value;
    void Start()
    {
        value = (int)Random.Range(1, 3) + 1;
        myPos = GetComponent<Transform>();
        myPos.localScale = new Vector3(value, value, 0);
    }

    public int GetValue()
    {
        return value;
    }
}
