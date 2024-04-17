using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using UnityEditor.Rendering;

public class DiceRandom : MonoBehaviour
{
    public GameObject one, two, three, four, five, six, dice;
    public static int diceNum;
    [SerializeField] PieceMovement pm;
    public void Start()
    {
        pm = FindObjectOfType<PieceMovement>();
        six.SetActive(true);
    }

    public void Update()
    { 
        if(pm.playState == PlayState.Player1WaitForMove || pm.playState == PlayState.Player2WaitForMove)
        { 
            Invoke("DiceActive", 2f);
        }      
    }

    void DiceActive()
    {
        dice.SetActive(true);
    }
    public void Roll()
    {
        diceNum = Random.Range(1, 7);

        StartCoroutine(Rolling(0.1f));

        StartCoroutine(Hide(3f));
    }
    private IEnumerator Hide(float time)
    {
        yield return new WaitForSeconds(time);
        dice.SetActive(false);
    }
    private IEnumerator Rolling(float time) 
    {
        for(int i = 0; i < 3; i++)
        {
            one.SetActive(true);
            yield return new WaitForSeconds(time);
            one.SetActive(false);

            two.SetActive(true);
            yield return new WaitForSeconds(time);
            two.SetActive(false);

            three.SetActive(true);
            yield return new WaitForSeconds(time);
            three.SetActive(false);

            four.SetActive(true);
            yield return new WaitForSeconds(time);
            four.SetActive(false);

            five.SetActive(true);
            yield return new WaitForSeconds(time);
            five.SetActive(false);

            six.SetActive(true);
            yield return new WaitForSeconds(time);
            six.SetActive(false);
        }
        
        if(diceNum == 1)
        {
            one.SetActive(true);   
        }
        else if(diceNum == 2)
        {
            two.SetActive(true);
        }
        else if(diceNum == 3)
        {
            three.SetActive(true);
        }
        else if(diceNum == 4)
        {
            four.SetActive(true);
        }
        else if(diceNum == 5)
        {
            five.SetActive(true);
        }
        else if(diceNum == 6)
        {
            six.SetActive(true);
        }
    }
}
