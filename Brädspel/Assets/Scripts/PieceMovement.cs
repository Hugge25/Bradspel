using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public GameObject Player1, Player2;
    public GameObject prefabStar, prefabBomb;
    public int p1Pos = 0;
    public int p2Pos = 0;
    private bool p1Turn = true;
    public TMP_Text tmp;
    public void Start()
    {
        Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
        Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
        tmp.text = "Spelare 1's Tur";

        GameObject bomb1 = Instantiate(prefabBomb, LevelGenerator.tiles[6].transform.position, Quaternion.identity, transform);
        GameObject bomb2 = Instantiate(prefabBomb, LevelGenerator.tiles[20].transform.position, Quaternion.identity, transform);
        GameObject bomb3 = Instantiate(prefabBomb, LevelGenerator.tiles[40].transform.position, Quaternion.identity, transform);
        GameObject bomb4 = Instantiate(prefabBomb, LevelGenerator.tiles[56].transform.position, Quaternion.identity, transform);

        GameObject star1 = Instantiate(prefabStar, LevelGenerator.tiles[3].transform.position, Quaternion.identity, transform);
        GameObject star2 = Instantiate(prefabStar, LevelGenerator.tiles[21].transform.position, Quaternion.identity, transform);
        GameObject star3 = Instantiate(prefabStar, LevelGenerator.tiles[37].transform.position, Quaternion.identity, transform);
        GameObject star4 = Instantiate(prefabStar, LevelGenerator.tiles[45].transform.position, Quaternion.identity, transform);
        
    }   

    public void Update()
    {
        p1Pos = Mathf.Min(p1Pos, 61);
        p2Pos = Mathf.Min(p2Pos, 61);

        if((Player1.transform.position == LevelGenerator.tiles[6].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[20].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[40].transform.position)|| 
            (Player1.transform.position == LevelGenerator.tiles[56].transform.position))
        {
            print("BombP1");
            Player1.transform.position = LevelGenerator.tiles[0].transform.position;
            p1Pos = 0;
        }

       if((Player2.transform.position == LevelGenerator.tiles[6].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[20].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[40].transform.position)|| 
            (Player2.transform.position == LevelGenerator.tiles[56].transform.position))
        {
            print("BombP2");
            Player2.transform.position = LevelGenerator.tiles[0].transform.position; 
            p1Pos = 0;
        }

        if(Player1.transform.position == LevelGenerator.tiles[62].transform.position)
        {
            p1Turn = false;
        }
        else if(Player2.transform.position == LevelGenerator.tiles[62].transform.position)
        {
            p1Turn = true;
        }
    }

    public void Move()
    {
        if(p1Turn)
        {
            try{
                p1Pos += DiceRandom.diceNum;
                Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
            }
            finally{
                tmp.text = "Spelare 2's Tur";
                p1Turn = false;
            }
            
        }
        else
        {
            try{
                p2Pos += DiceRandom.diceNum;
                Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
            }
            finally{
                tmp.text = "Spelare 1's Tur";
                p1Turn = true;
            }
            
        }
    }
}
