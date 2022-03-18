using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovements : MonoBehaviour
{
    public float selfRevolutionSpeed = 1;
  //  public bool isOrbitalRevolution = false;
  //  public float orbitalRevolutionSpeed = 1;
  //  public GameObject center;
    // Start is called before the first frame update

    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, selfRevolutionSpeed*Time.deltaTime, 0, Space.Self);
      // This works, but the axis need to be calculated manually
        //if (isOrbitalRevolution)
        //{
        //    transform.RotateAround(center.transform.position, new Vector3(0,1,0),orbitalRevolutionSpeed*Time.deltaTime);

        //}
    }
}
