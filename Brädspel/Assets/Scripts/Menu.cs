using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Spela(){
        SceneManager.LoadScene(1);
    }

    public void Settings(){
        Debug.Log("Inställningar");
    }

    public void Exit(){
        Debug.Log("Avsluta");
        Application.Quit();
    }
}
