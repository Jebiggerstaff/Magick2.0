using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{
    public float lifeTimer = 10;
    private void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f)
        {
            Object.Destroy(gameObject);
        }
        lifeTimer -= Time.deltaTime;

    }
}

