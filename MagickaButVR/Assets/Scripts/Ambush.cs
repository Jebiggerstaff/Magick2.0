using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambush : MonoBehaviour
{
    public GameObject[] goblins;
    public int deadGoblins;
    public bool ambushStart = false;
    public bool ambushFinished = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (ambushStart && !ambushFinished)
        {
            if(PersistentManager.instance.GetZone() != "Forest")
            {
                for(int i = 0; i < goblins.Length - 1; i++)
                {
                    goblins[i].GetComponent<SamBrain>().DeAggro();
                }
                AmbushOver();
            }
            else if (GoblinsGone())
            {
                AmbushOver();
            }
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Player")
        {
            goblins[0] = (GameObject)Instantiate(Resources.Load("Sam"), new Vector3(), new Quaternion());
            goblins[1] = (GameObject)Instantiate(Resources.Load("Sam"), new Vector3(), new Quaternion());
            goblins[2] = (GameObject)Instantiate(Resources.Load("Sam"), new Vector3(), new Quaternion());
            goblins[3] = (GameObject)Instantiate(Resources.Load("Sam"), new Vector3(), new Quaternion());
            goblins[4] = (GameObject)Instantiate(Resources.Load("Sam"), new Vector3(), new Quaternion());
            PersistentManager.instance.totalGoblins += 5;
            ambushStart = true;
        }
    }

    bool GoblinsGone()
    {
        for(int i = 0; i < goblins.Length - 1; i++)
        {
            if (goblins[i] == null)
                deadGoblins++;
        }
        if (deadGoblins == goblins.Length)
            return true;
        else
            return false;
    }

    void AmbushOver()
    {
        ambushFinished = true;
        PersistentManager.instance.TaskComplete(true, "You have survived the goblin ambush.");
        PersistentManager.instance.surviveAmbushCB.SetActive(true);
        Destroy(gameObject);
    }
}
