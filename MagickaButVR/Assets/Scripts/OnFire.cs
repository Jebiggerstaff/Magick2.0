using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : MonoBehaviour
{
    private bool Dying = false;

    void Update()
    {
		if (gameObject.tag == "Enemy" && gameObject.name=="Sam")
		{
            if (Dying == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
                Invoke("KillSam", .552f);
                Dying = true;
               
            }
		}
    }

    void KillSam()
    {
        PersistentManager.instance.GoblinKilled(true);
        Dying = false;
        Destroy(gameObject);
    }
}
