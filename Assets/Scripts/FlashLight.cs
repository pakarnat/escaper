using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour
{

    public Light light;    //assign gameobject with light component attached

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {      //Left mouse button
            light.enabled = !light.enabled;      //changes light on/off
        }
        if (Input.GetMouseButtonDown(1))
        {
            Color valo1 = new Color(255f,255f,10f,255f);
            Color valo2 = new Color(255f, 10f, 10f,255f);
            Color valo3 = new Color(10f, 10f, 255f,255f);
            Color valo4 = new Color(10f, 255f, 10f,255f);
            if (light.color == valo1){
                light.color = valo2;
            }
            else if (light.color == valo2)
            {
                light.color = valo3;
            }
            else if (light.color == valo3)
            {
                light.color = valo4;
            }
            else if (light.color == valo4)
            {
                light.color = valo1;
            }
            else
            {
                light.color = valo1;
            }
        }
    }
}
