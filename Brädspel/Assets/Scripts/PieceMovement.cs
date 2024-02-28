using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public PieceSelecter pieceSelecter;

    public GameObject Gs1;
    public GameObject Ht1;
    public GameObject Kn1;
    public GameObject Hd1;
    public GameObject Gs2;
    public GameObject Ht2;
    public GameObject Kn2;
    public GameObject Hd2;

    public void Start(){

    }
    public void Update()
    {
        if(pieceSelecter.p1 == 1)
        {
            Gs1.SetActive(true);
        }
        else if(pieceSelecter.p1 == 2){
            Ht1.SetActive(true);
        } 

        if(pieceSelecter.p2 == 1)
        {
            Gs2.SetActive(true);
        }
        else if(pieceSelecter.p2 == 2){
            Ht2.SetActive(true);
        }   
    }
}
