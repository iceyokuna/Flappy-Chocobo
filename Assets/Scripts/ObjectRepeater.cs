using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRepeater : MonoBehaviour
{

    public Transform Object;

    public float delay;
    public float minY;
    public float maxY;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1, delay);
    }

    void Spawn()
    {
		Vector3 position = Object.position;
		if(Object.tag == "coin")
		{
			position.y = Random.Range(minY, maxY);
			int coin_num = Random.Range(0, 6);
			int direction = Random.Range(0, 5);
			for (int i = 0; i < coin_num; i++) 
			{
				Instantiate (Object, position, Quaternion.identity);
				if(direction > 2)
					position.y -= 1;
				else
					position.y += 1;
				position.x += 1;
			}
			return;
		}
        position.y = Random.Range(minY, maxY);
        GameObject.Instantiate(Object, position, Quaternion.identity);

    }
}
