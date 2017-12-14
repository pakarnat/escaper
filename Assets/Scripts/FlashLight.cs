using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour
{
    
    private Camera ItemCamera;
    private int normalMask;
    
    public Light redLight;
    public Light greenLight;
    public Light whiteLight;
    private Light currentLight;
    private RaycastHit hit;

    //assign gameobject with light component attached
    private void Awake()
    {
        currentLight = whiteLight;
        currentLight.enabled = true;
        redLight.enabled = greenLight.enabled = false;
    }

    void Update()
    {
        if (this.GetComponentInParent<Item>().isEquipped)
        {
            ItemCamera = GetComponentInParent<Camera>();
            normalMask = ItemCamera.cullingMask;
       
            if (Input.GetMouseButtonDown(0))
            {
                if (currentLight.enabled == true)
                {
                    if(currentLight == whiteLight)
                    {
                        WhiteLightOff();                        
                    }
                    else if(currentLight == greenLight)
                    {
                        GreenLightOff();
                    }
                    else if(currentLight == redLight)
                    {
                        RedLightOff();
                    }
                }
                else if (currentLight.enabled == false)
                {
                    if(currentLight == whiteLight)
                    {
                        WhiteLightOn();
                    }
                    else if(currentLight == greenLight)
                    {
                        GreenLightOn();
                    }
                    else if(currentLight == redLight)
                    {
                        RedLightOn(); 
                    }
                }
                
            }
            if (Input.GetMouseButtonDown(1))
            {
                if(currentLight == whiteLight)
                {
                    if (currentLight.enabled)
                    {
                        WhiteLightOff();
                        RedLightOn();
                    }
                    currentLight = redLight;
                }
                else if(currentLight == redLight)
                {
                    if (currentLight.enabled)
                    {
                        RedLightOff();
                        GreenLightOn();
                    }
                    currentLight = greenLight;
                }
                else if(currentLight == greenLight)
                {
                    if (currentLight.enabled)
                    {
                        GreenLightOff();
                        WhiteLightOn();
                    }
                    currentLight = whiteLight;
                }
                else
                {
                    if (currentLight.enabled)
                    {
                        RedLightOff();
                        GreenLightOff();
                        WhiteLightOn();
                    }
                    currentLight = whiteLight;
                }                
            }
            if(currentLight == redLight)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward) * 35;
                Debug.DrawRay(transform.position, forward, Color.red);

                if (currentLight.enabled == true)
                {
                    if (Physics.Raycast(transform.position, forward, out hit, 30))
                    {
                        GameObject enemy = hit.collider.gameObject;
                        if (enemy.tag == "Enemy")
                        {
                            enemy.GetComponent<GhostFollow>().TakeDamage();
                        }
                    }
                }
            }
        }
        else if (this.GetComponentInParent<Item>().InInventory())
        {
            whiteLight.enabled = redLight.enabled = greenLight.enabled = currentLight.enabled = false;
        }
    }
    void GreenLightOn()
    {
        redLight.enabled = whiteLight.enabled = false;         
        currentLight = greenLight;
        currentLight.enabled = true;
        ItemCamera.cullingMask |= (1 << LayerMask.NameToLayer("GreenEaster"));
    }
    void GreenLightOff()
    {
        currentLight.enabled = false;
        ItemCamera.cullingMask = ~(1 << LayerMask.NameToLayer("RedEaster") | (1 << LayerMask.NameToLayer("GreenEaster") | (1 << LayerMask.NameToLayer("Minimap"))));
    }
    void RedLightOn()
    {
        whiteLight.enabled = greenLight.enabled = false;        
        currentLight = redLight;
        currentLight.enabled = true;
        ItemCamera.cullingMask |= (1 << LayerMask.NameToLayer("RedEaster"));
    }
    void RedLightOff()
    {
        currentLight.enabled = false;
        ItemCamera.cullingMask = ~(1 << LayerMask.NameToLayer("RedEaster") | (1 << LayerMask.NameToLayer("GreenEaster") | (1 << LayerMask.NameToLayer("Minimap"))));
    }
    void WhiteLightOn()
    {
        greenLight.enabled = redLight.enabled = false;        
        currentLight = whiteLight;
        currentLight.enabled = true;
        ItemCamera.cullingMask = ~(1 << LayerMask.NameToLayer("RedEaster") | (1 << LayerMask.NameToLayer("GreenEaster") | (1 << LayerMask.NameToLayer("Minimap"))));
    }
    void WhiteLightOff()
    {
        currentLight.enabled = false;
        whiteLight.enabled = false;
        ItemCamera.cullingMask = ~(1 << LayerMask.NameToLayer("RedEaster") | (1 << LayerMask.NameToLayer("GreenEaster") | (1 << LayerMask.NameToLayer("Minimap"))));
    }
    
}
