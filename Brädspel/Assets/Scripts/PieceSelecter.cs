using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelecter : MonoBehaviour
{
    public int p1;
    public int p2;

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
}
