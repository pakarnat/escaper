using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lautta : MonoBehaviour
{

    public Transform target;
    public Transform Start;
    public float speed;
    public float odotusaika = 5;
    public GameObject player;
    public Transform platform;
    int x = 0;
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (x == 0)
        {
            // lautta menee 2 kohteeseen (eli saarelle)
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (transform.position == target.position)
            {
                StartCoroutine(Odotus());
            }
        }

        if (x == 1) {
            //kun lautta saavuttaa saaren niin se lähtee takasin alku pisteeseen
            transform.position = Vector3.MoveTowards(transform.position, Start.position, step);
            if(transform.position == Start.position)
            {
                StartCoroutine(Odotus());
            }
        }
        
    }
    //lautta odottaa odotusajan verran kohteessa ennenkuin kääntää suunnan takasin toiseen kohteeseen
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
