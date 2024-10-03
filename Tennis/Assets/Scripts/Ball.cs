using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    Vector3 intitalpos;
    int PlayerScore;
    int botScore;
    public bool Playing = true;
    public string hitter;
    [SerializeField] Text palyerscoreText;
    [SerializeField] Text botscoreText;
    void Start()
    {
        intitalpos = transform.position;
         PlayerScore=0;
         botScore=0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            // transform.position = intitalpos;
            GameObject.Find("Player").GetComponent<Player>().Reset();
            if (Playing)
            {
                if (hitter == "Player")
                {
                    PlayerScore++;
                }
                else if (hitter == "bot")
                {
                    botScore++;

                }
                Playing = false;
                UpdateScore();
            }
           
        }
        else if (collision.transform.CompareTag("out"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find("Player").GetComponent<Player>().Reset();
            if (Playing)
            {
                if (hitter == "Player")
                {
                    PlayerScore++;
                }
                else if (hitter == "bot")
                {
                    botScore++;

                }
                Playing = false;
                UpdateScore();
            }

           

        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("out")&&Playing)
        {
            if (hitter=="Player")
            {
                botScore++;
            }
            else if(hitter=="bot")
            {
                PlayerScore++;
            
            }
            Playing = false;
            UpdateScore();

        }
       
    }
    void UpdateScore()
    {
        palyerscoreText.text = "Player :" + PlayerScore;
        botscoreText.text =   "bot :" + botScore;
    }
}
