using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoController : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D rigidbody2D;

    private bool died;

    public Vector2 velocity;

    public AudioClip fly;
    public AudioClip hit;
    public AudioClip collect;

    public UImanager uiManager;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        died = false;
        Fly();
    }

    // Fly method
    void Fly()
    {
        animator.SetTrigger("IsFly");
        audioSource.PlayOneShot(fly);

        rigidbody2D.velocity = velocity;
        FlyUp();
    }

    void FlyUp()
    {
        float angle_z = transform.eulerAngles.z;    
        if (angle_z > 180)
            angle_z -= 360;

        if (angle_z < 30)
            transform.Rotate(0, 0, 30 - angle_z);
    }

    void DropDown()
    {
        float angle_z = transform.eulerAngles.z;
        //float down_angle = (angle_z > -45) ? -2 : 0;
        // if angle_z > -45 -> down_angle -2 else = -0
        if (angle_z > 180)
            angle_z -= 360;
        
        if(angle_z > -45)
            transform.Rotate(0, 0, -2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(died == true)
            return;
		
		animator.SetTrigger("Die");
        audioSource.PlayOneShot(hit);
        died = true;

        Invoke("OnDied",1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        uiManager.Inc_score();

        audioSource.PlayOneShot(collect);

        if (collision.gameObject.CompareTag("coin"))
            Destroy(collision.gameObject);

    }


    void OnDied()
    {
        //int level = Application.loadedLevel;
        //Application.LoadLevel(level);

        uiManager.ShowResult();

    } 

    // Update is called once per frame
    void Update ()
    {
        bool keyDown = Input.GetKeyDown(KeyCode.Space);
        bool mouseClick = Input.GetMouseButtonDown(0);

        if((keyDown || mouseClick) && died == false)
        {
            Fly();
        }
        else
        {
            DropDown();
        }
	}
}
