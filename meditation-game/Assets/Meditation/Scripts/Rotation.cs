using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool independentChild;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (independentChild) {
            //planet should always be the second child
            Quaternion savedRotation = this.gameObject.transform.GetChild(1).transform.localRotation;

            Vector3 v = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(v.x, v.y + (speed) * Time.deltaTime, v.z);

            this.gameObject.transform.GetChild(1).transform.localRotation = savedRotation;
            Vector3 u = this.gameObject.transform.GetChild(1).transform.localRotation.eulerAngles;
            this.gameObject.transform.GetChild(1).transform.localRotation = Quaternion.Euler(u.x, u.y, u.z + (speed/2f) * Time.deltaTime);
        } else
        {
            Vector3 v = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(v.x, v.y + speed * Time.deltaTime, v.z);
        }
        
    }
}
