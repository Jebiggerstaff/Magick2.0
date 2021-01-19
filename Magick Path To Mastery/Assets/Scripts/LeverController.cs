using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    public GameObject player;
    public GameObject gate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PersistentManager.instance.openPortcullis = true;
            PersistentManager.instance.openPortcullisCB.SetActive(true);
            PersistentManager.instance.TaskComplete(true, "Opened the Portcullis");
            Destroy(gate);
        }
    }
}
