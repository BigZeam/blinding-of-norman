using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    GameObject player;
    void Start()
    {
        transform = GetComponent<Transform>();
        transform.localScale = new Vector3(Random.Range(10, 30), Random.Range(10, 30), 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
