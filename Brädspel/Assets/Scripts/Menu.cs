using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /*[SerializeField] PieceMovement pm;

    public void Start()
    {
        pm = FindObjectOfType<PieceMovement>();
    }
    */
    public void Spela(){
        SceneManager.LoadScene(1);
        //pm.start = true;
    }

    public void Exit(){
        Debug.Log("Avsluta");
        Application.Quit();
    }
}
