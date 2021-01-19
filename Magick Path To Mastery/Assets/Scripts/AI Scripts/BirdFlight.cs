using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlight : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Speed);
    }
}
