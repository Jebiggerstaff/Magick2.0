using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballVr : MonoBehaviour
{
    public CastMagic castMagic;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
