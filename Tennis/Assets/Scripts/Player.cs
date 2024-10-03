using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    public Transform aimtarget;
    public Transform ball;

    float Speed = 3f;
   // float force = 6f;
    Animator anim;
    CharacterController cc;
    Vector3 aimtargetintialposition;
    bool hitting;

    ShotManager shotmanager;
    Shot currentshot;
    [SerializeField] Transform ServeRight;
    [SerializeField] Transform ServeLeft;

    bool ServedRight = true;
    public static int batChoice;
    public GameObject[] Bats;
    public GameObject Bat2;

    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        aimtargetintialposition = aimtarget.position;
        shotmanager = GetComponent<ShotManager>();
        currentshot = shotmanager.topSpin;
        Batchange(batChoice);
    }

   
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 z = new Vector3(0, 0, v) * Time.deltaTime * Speed;
        z = transform.TransformDirection(z);
        cc.Move(z);

        Vector3 x = new Vector3(h, 0, 0) * Speed * Time.deltaTime;
        x = transform.TransformDirection(x);
        cc.Move(x);

     /*   if ( h !=0 || v !=0)
        {
            transform.Translate(new Vector3(h, 0, v) * Speed * Time.deltaTime);
        }*/
        if (h < 0   )
        {
            anim.SetBool("left",true);
        }
        else
        {
            anim.SetBool("left", false);
        }
        if (h > 0 )
        {
            anim.SetBool("right", true);
        }
        else
        {
            anim.SetBool("right", false);
        }
        if (v < 0)
        {
            anim.SetBool("backward", true);
        }
        else
        {
            anim.SetBool("backward", false);
        }
        if (v > 0)
        {
            anim.SetBool("forward", true);
        }
        else
        {
            anim.SetBool("forward", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true;
            currentshot = shotmanager.topSpin;
            Speed = 0;
            anim.enabled = false;
            
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false;
            Speed = 3;
            anim.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting = true;
            currentshot = shotmanager.flat;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting = false;
          
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            hitting = true;
            currentshot = shotmanager.flatserve;
            GetComponent<BoxCollider>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            hitting = true;
            currentshot = shotmanager.kickserve;
            GetComponent<BoxCollider>().enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.T))
        {
            hitting = false;
            GetComponent<BoxCollider>().enabled = true;
            ball.transform.position = transform.position + new Vector3(0.2f, 1, 0);
            Vector3 dir = aimtarget.position - transform.position;
            ball.GetComponent<Rigidbody>().velocity = dir.normalized * currentshot.hitForce + new Vector3(0, currentshot.upForce, 0);
            ball.GetComponent<Ball>().hitter = "Player";
            ball.GetComponent<Ball>().Playing = true;
        }

        

        if (hitting)
        {
            aimtarget.Translate(new Vector3(h, 0, 0) *  3 * Time.deltaTime);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            anim.Play("hit");
            Vector3 dir = aimtarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized*currentshot.hitForce + new Vector3(0,currentshot.upForce,0);
            
           
          
            Vector3 ballDir = ball.position - transform.position;

            if (ballDir.x >= 0)
            {
                Debug.Log("Forehead");
            }
            else
            {
                Debug.Log("backend");
            }
            ball.GetComponent<Ball>().hitter = "Player";
        }
       

        aimtarget.position = aimtargetintialposition;
    }
    public void Reset()
    {
        if (ServedRight)
            transform.position = ServeLeft.position;
        else
            transform.position = ServeRight.position;
        ServedRight = !ServedRight;
    }
    public void Batchange(int i)
    {
        foreach(GameObject bat in Bats)
        {
            bat.SetActive(false);
        }
        Bats[i].SetActive(true);
    }
}
