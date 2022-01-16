using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    float rayLength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
           
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                if (hit.collider.tag == "button")
                {
                    hit.collider.gameObject.GetComponent<ButtonScript>().interactEvent.Invoke();
                }
            }
        }


    }
}
