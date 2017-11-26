using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lautta : MonoBehaviour
{

    public Transform target;
    public Transform Start;
    public float speed;
    public float odotusaika = 5;
    int x = 0;
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (x == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (transform.position == target.position)
            {
                StartCoroutine(Odotus());
            }
        }

        if (x == 1) {
            transform.position = Vector3.MoveTowards(transform.position, Start.position, step);
            if(transform.position == Start.position)
            {
                StartCoroutine(Odotus());
            }
        }
        
    }
    IEnumerator Odotus()
    {
        if (x == 0)
        {
            yield return new WaitForSeconds(odotusaika);
            x = 1;
            yield break;
        }
        if (x == 1)
        {
            yield return new WaitForSeconds(odotusaika);
            x = 0;
            yield break;
        }
        

    }
}
