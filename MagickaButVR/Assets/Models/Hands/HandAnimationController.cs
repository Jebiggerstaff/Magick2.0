using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    public AnimationClip handClose;

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            gameObject.GetComponent<Animator>().SetBool("Playing", true);
            Invoke("StopAnim",handClose.length);
        }
    }

    void StopAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("Playing", false);

    }
}
