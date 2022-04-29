using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognizePlayer : MonoBehaviour
{
    public EnemyController ec;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            ec.SetAttack(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            ec.SetAttack(false);
        }
    }
}
