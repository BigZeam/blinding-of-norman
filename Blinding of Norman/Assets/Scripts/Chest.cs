using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnables;
    int rand;

    public void Open()
    {
        rand = Random.Range(0, spawnables.Length);
        Instantiate(spawnables[rand], this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
