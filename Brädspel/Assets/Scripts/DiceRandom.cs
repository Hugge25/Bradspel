using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRandom : MonoBehaviour
{
    public TMP_Text tmp;
    public static int diceNum;
    public void Roll()
    {
        diceNum = Random.Range(1, 7);

        tmp.text = diceNum.ToString();
    }
}
