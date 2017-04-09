using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostTraslator : MonoBehaviour {

    public float speed;
    public float follow_speed;
    public float left;
    public float distance;


    // Update is called once per frame
    void Update ()
    {
        Vector3 position = new Vector3(transform.position.x , 0, 0);

        if (position.x < left)
        {
            Destroy(gameObject);
            return;
        }

        distance -= follow_speed;

        if(distance >= 150 || distance <= 0)
        {
            follow_speed *= -1;
        }

        transform.Translate(-speed * Time.deltaTime, follow_speed * Time.deltaTime, 0);

    }
}
