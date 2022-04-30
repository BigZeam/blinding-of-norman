using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Debug.Log("We attaacked");
        yield return new WaitForSeconds(.5f);

        Destroy(this.gameObject);
    }
}
