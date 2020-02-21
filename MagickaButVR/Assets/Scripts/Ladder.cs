using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public GameObject player;


    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject == player)
        {
            player.GetComponent<FirstPersonAIO>().useHeadbob = false;
            player.GetComponent<Transform>().position += new Vector3(0, .2f, 0);
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        player.GetComponent<FirstPersonAIO>().useHeadbob = true;
    }

}
