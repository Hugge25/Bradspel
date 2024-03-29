using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
enum PlayState{
    Player1WaitForMove,
    Player1Moving,
    Player2WaitForMove,
    Player2Moving,
}
public class PieceMovement : MonoBehaviour
{
    public GameObject Player1, Player2;
    public GameObject prefabStar, prefabBomb;
    public int p1Pos = 0;
    public int p2Pos = 0;
    private bool p1Finish = false;
    private bool p2Finish = false;
    public TMP_Text tmp;

    private PlayState playState = PlayState.Player1WaitForMove;
    public void Start()
    {
        Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
        Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
        playState = PlayState.Player1WaitForMove;

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

        if(playState == PlayState.Player1WaitForMove){
            tmp.text = "Spelare 1's Tur"; 
        }
        else if(playState == PlayState.Player1Moving ){
            MovePlayer1();
        }
        else if(playState == PlayState.Player2WaitForMove){
            tmp.text = "Spelare 2's Tur";
        }
        else if(playState == PlayState.Player2Moving ){
            MovePlayer2();
        }

        
        if(p1Pos == 62){
            p1Finish = true;
        }
        if(p2Pos == 62){
            p2Finish = true;
        }


    }

    void MovePlayer1(){
        p1Pos += DiceRandom.diceNum;
        int moves = math.min(p1Pos,LevelGenerator.tiles.Count-1);
        Player1.transform.position = LevelGenerator.tiles[moves].transform.position;    
        playState = PlayState.Player2WaitForMove;
    }

    void MovePlayer2(){
        p2Pos += DiceRandom.diceNum;
        int moves = math.min(p2Pos,LevelGenerator.tiles.Count-1);
        Player2.transform.position = LevelGenerator.tiles[moves].transform.position;
        playState = PlayState.Player1WaitForMove;
    }

    public void SwitchState(){
            if(playState == PlayState.Player1WaitForMove && !p1Finish){
                playState = PlayState.Player1Moving;
                print("Switch to p1");
            }
            if(playState == PlayState.Player2WaitForMove && !p2Finish){
                playState = PlayState.Player2Moving;
                print("Switch to p2");
            }
    }
}
