using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public GameObject Player1, Player2;
    public int p1Pos = 0;
    public int p2Pos = 0;
    private bool p1Turn = true;
    public void Start()
    {
        Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
        Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
    }   

    public void Update()
    {

    }

    public void Move()
    {
        if(p1Turn)
        {
            p1Pos += DiceRandom.diceNum;
            Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
        }
        else
        {
            p2Pos += DiceRandom.diceNum;
            Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
        }
    }
}
