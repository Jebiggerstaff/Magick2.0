using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineWall : MonoBehaviour
{
    public GameObject VineWall1;
    public GameObject VineWallOpen;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.transform.name == "Fireball(Clone)")
        {
            VineWall1.SetActive(false);
            VineWallOpen.SetActive(true);

            PersistentManager.instance.burnVines = true;
            PersistentManager.instance.burnVinesCB.SetActive(true);
            PersistentManager.instance.TaskComplete(true, "The vines have been cleared from the path.");

            Destroy(gameObject);
        }
    }

}
