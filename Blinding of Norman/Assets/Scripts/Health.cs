using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    Transform myPos;
    int value;
    void Start()
    {
        value = Random.Range(10, 20);
        Debug.Log(value);
        myPos = GetComponent<Transform>();
        myPos.localScale = new Vector3(value/5, value/5, 0);
    }

    public int GetValue()
    {
        Debug.Log(value);
        return value;
    }
}
