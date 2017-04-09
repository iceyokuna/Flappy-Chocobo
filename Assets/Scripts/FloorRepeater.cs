using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRepeater : MonoBehaviour {

    public float speed;
    public float left;
    public float offset;
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;

        if(position.x < left)
            transform.Translate(offset, 0, 0);

        transform.Translate(-speed * Time.deltaTime , 0 , 0);
	}
}
