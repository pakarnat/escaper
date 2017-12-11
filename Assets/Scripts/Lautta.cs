using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lautta : MonoBehaviour
{

    public Transform target; //kohta mihinkä halutaan lautan menevän
    public Transform Start; // kohta mistä lauttan matka alkaa ja samalla paluupiste
    public float speed = 35; // lautan nopeus
    public float odotusaika = 5; // kuinka kauan lautta odottaa maissa
    public GameObject player; //pelaajan hahmo
    public Transform platform; // lautassa oleva tyhjä peliobjecti jolla otetaan pelaaja kiinni
    int x = 0; // kumpaan suuntaan lautta on menossa
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
