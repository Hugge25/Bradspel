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
    public GameObject SB1, SB2, SB3, SB4, SB5, SB6, SB7, SB8;

    public int p1;
    public int p2;
    
    public void Start()
    {
        LoadData();
    }

    public void GrisP1(){
        Debug.Log("p1, 1");
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
        switch (p1)
        {
            case 1:
                if (Gs1 != null)
                    Gs1.SetActive(true);
                break;
            case 2:
                if (Ht1 != null)
                    Ht1.SetActive(true);
                break;
            case 3:
                if (Kn1 != null)
                    Kn1.SetActive(true);
                break;
            default:
                if (Hd1 != null)
                    Hd1.SetActive(true);
                break;
        }

        switch (p2)
        {
            case 1:
                if (Gs2 != null)
                    Gs2.SetActive(true);
                break;
            case 2:
                if (Ht2 != null)
                    Ht2.SetActive(true);
                break;
            case 3:
                if (Kn2 != null)
                    Kn2.SetActive(true);
                break;
            default:
                if (Hd2 != null)
                    Hd2.SetActive(true);
                break;
        }


        if(p1 == p2)
        {
            if(p2 == 4)
            {
                p2 = 1;
            }
            else
                p2 += 1;
        }

        if(p1 == 1){
            Debug.Log("active" + SB4);
            SB4.SetActive(true);
        }
        else{SB4.SetActive(false);}

        if(p1 == 2){
            SB3.SetActive(true);}
        else{SB3.SetActive(false);}

        if(p1 == 3){
            SB2.SetActive(true);}
        else{SB2.SetActive(false);}

        if(p1 == 4){
            SB1.SetActive(true);}
        else{SB1.SetActive(false);}

        if(p2 == 1){
            SB8.SetActive(true);}
        else{SB8.SetActive(false);}

        if(p2 == 2){
            SB7.SetActive(true);}
        else{SB7.SetActive(false);}

        if(p2 == 3){
            SB6.SetActive(true);}
        else{SB6.SetActive(false);}

        if(p2 == 4){
            SB5.SetActive(true);}
        else{SB5.SetActive(false);}

    }
}
