using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public GameObject gm;
    public GameObject gm2;
    public Button Uparrow;
    public Button Downarrow;
    public GameObject up;
    public GameObject down;

    public GameObject Pb;
  
    public GameObject players;
    public GameObject bat;
    public GameObject List;
    public GameObject Control;

    //public  Player Playerscript;
    void Start()
    {
        
        gm2.SetActive(false);
        gm.SetActive(false);
        Pb.SetActive (false);
        bat.SetActive(false);
        List.SetActive(false);
        Control.SetActive(false);
       
      //  Playerscript= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Play()
    {
         SceneManager.LoadScene("SampleScene");
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    //playerbutton
    public void playerbutton()
    {
        players.SetActive(true);
        bat.SetActive(false);
        Pb.SetActive(true);
        gm.SetActive(true);
        gm2.SetActive(false);
        List.SetActive(false);
        Control.SetActive(false);
    }
    public void uparrow()
    {
        gm2.SetActive(true);
        gm.SetActive(false);
    }
    public void downarrow()
    {
        gm2.SetActive(false);
        gm.SetActive(true);
    }
    //Equipmentbutton
    public void eq()
    {
        Pb.SetActive(false);
        players.SetActive(false);
        bat.SetActive(true);
        List.SetActive(false);
        Control.SetActive(false);
    }
    public void settings()
    {
        Pb.SetActive(false);
        players.SetActive(false);
        bat.SetActive(false);
        List.SetActive(true);
        List.SetActive(true);
        Control.SetActive(false);
    }
    public void control()
    {
        Pb.SetActive(false);
        players.SetActive(false);
        bat.SetActive(false);
        List.SetActive(false);
        Control.SetActive(true);
    }
    public void batchange()
    {
       // Playerscript.Batchange();
    }
}
