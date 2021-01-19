using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHalo : MonoBehaviour
{
    public float glowMult = 1.5f;
    float size;

    private void Update()
    {
        size = (transform.parent.localScale.x + transform.parent.localScale.y + transform.parent.localScale.z) / 3f + glowMult * (transform.parent.localScale.x + transform.parent.localScale.y + transform.parent.localScale.z) / 3f;
        GetComponent<Light>().range = size;
    }
}
