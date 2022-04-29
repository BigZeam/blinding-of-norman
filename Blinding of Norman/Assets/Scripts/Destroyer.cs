using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    int timer = 0;
    bool doors = true;
    GameObject getDestroyed;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Closed" || other.gameObject.tag == "Door")
        {
            Destroy(other.gameObject);
        }
            


            //Destroy(other.gameObject);
            getDestroyed = other.gameObject;
            
            //StartCoroutine(Die());
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //Destroy(other.gameObject);
        
    }
    /* 
    IEnumerator Die()
    {
        Debug.Log("This object will die");
        yield return new WaitForSeconds(4f);
        Destroy(getDestroyed);

    }
    */

}
