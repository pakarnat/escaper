using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lautta : MonoBehaviour
{

    public Transform target;
    public Transform Start;
    public float speed;

    int x;
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (x == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (transform.position == target.position)
            {
                x = 1;
            }
        }

        if (x == 1) {
            transform.position = Vector3.MoveTowards(transform.position, Start.position, step);
            if(transform.position == Start.position)
            {  
                x = 0;
            }
        }
        
    }
}
