using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    float Speed=9;
    float force = 6f;

    public Transform ball;
    public Transform aimtarget;
    public Transform[] targets;

    Animator anim;
    Vector3 targetposition;

    void Start()
    {
        targetposition = transform.position;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
       
    }

     void Move()
    {
        targetposition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetposition, Speed * Time.deltaTime);
    }

    Vector3 pickTarget()
    {
        int randomvalue = Random.Range(0, targets.Length);
        return targets[randomvalue].position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = pickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 4.5f, 0);

            anim.SetBool("hit", true);

            Vector3 ballDir = ball.position - transform.position;

            if (ballDir.x >= 0)
            {
                Debug.Log("Forehead");
            }
            else
            {
                Debug.Log("backend");
            }

        }
        else
        {
            anim.SetBool("hit", false);
        }

        ball.GetComponent<Ball>().hitter = "bot";
    }


}
