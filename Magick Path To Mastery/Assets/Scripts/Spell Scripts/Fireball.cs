using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float lifeTimer = 10;
    float explosionTimer = 3;
    bool collide = false;

    public AudioClip Explosion;
    void Start()
    {
        
    }

    void Update()
    {
        if (collide == false)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 1000f * Time.deltaTime;
        }
        else
        {
            explosionTimer -= Time.deltaTime;
            if (explosionTimer <= 0)
            {
                Object.Destroy(gameObject);
            }
        }
        lifeTimer -= Time.deltaTime;  

        if(lifeTimer <= 0f && collide == false)
        {
            Object.Destroy(gameObject);
        }
        lifeTimer -= Time.deltaTime;
    }

	void OnTriggerEnter(Collider obj)
	{
		if (obj.tag != "FireballIgnore")
		{
			GameObject temp;

			if (lifeTimer <= 9.9 && obj.tag != "Task")
			{
				collide = true;
				GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                temp = obj.gameObject;
                temp.AddComponent<OnFire>();
                GetComponent<AudioSource>().clip = Explosion;
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().volume = 1f;
                GetComponent<AudioSource>().Play();
                //Debug.Log(temp.name + "temp");
                Invoke("DestoryThis", Explosion.length);
			}
		}
    }
    void DestoryThis()
    {
        Destroy(gameObject);
    }
}
