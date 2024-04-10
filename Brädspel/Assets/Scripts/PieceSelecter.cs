using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelecter : MonoBehaviour
{
    public GameObject Gs1;
    public GameObject Ht1;
    public GameObject Kn1;
    public GameObject Hd1;
    public GameObject Gs2;
    public GameObject Ht2;
    public GameObject Kn2;
    public GameObject Hd2;

    public int p1;
    public int p2;
    
    public void Start()
    {
        LoadData();
    }

    public void GrisP1(){
        p1 = 1;
    }
    public void GrisP2(){
        p2 = 1;
    }


    public void HästP1(){
        p1 = 2;
    }
    public void HästP2(){
        p2 = 2;
    }


    public void KaninP1(){
        p1 = 3;
    }
    public void KaninP2(){
        p2 = 3;
    }


    public void HundP1(){
        p1 = 4;
    }
    public void HundP2(){
        p2 = 4;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Player1", p1);
        PlayerPrefs.SetInt("Player2", p2);
    }

    public void LoadData()
    {
        p1 = PlayerPrefs.GetInt("Player1");
        p2 = PlayerPrefs.GetInt("Player2");
    }

    public void Update()
    {
        if(p1 == 1)
        {
            Gs1.SetActive(true);
        }
        else if(p1 == 2){
            Ht1.SetActive(true);
        } 
        else if(p1 == 3){
            Kn1.SetActive(true);
        }  
        else{
            Hd1.SetActive(true);
        } 

        if(p2 == 1)
        {
            Gs2.SetActive(true);
        }
        else if(p2 == 2){
            Ht2.SetActive(true);
        }
        else if(p2 == 3){
            Kn2.SetActive(true);
        }  
        else{
            Hd2.SetActive(true);
        }
    }
}
