using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public bool Finished = false;
    public GameObject Endscreen;
    public GameObject Potion;
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player&&Finished==false)
        {
            Finished = true;
            DisplayEndScreen();
        }
    }

    public void DisplayEndScreen()
    {
        Endscreen.SetActive(true);
        Invoke("CloseEndScreen", 5f);
        Potion.SetActive(false);
    }

    public void CloseEndScreen()
    {
        Endscreen.SetActive(false);
    }

}
