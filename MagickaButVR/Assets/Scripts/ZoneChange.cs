using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChange : MonoBehaviour
{
	public string zone;

    void OnTriggerEnter(Collider obj)
	{
		if(obj.tag == "Player" && PersistentManager.instance.GetZone() != zone)
		{
			PersistentManager.instance.SetZone(zone);
		}
	}
}
