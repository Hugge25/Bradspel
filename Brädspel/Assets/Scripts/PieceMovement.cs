using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography;
using JetBrains.Annotations;
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
    public GameObject gris, hund, kanin, hest;
    public GameObject Player1, Player2;
    public GameObject prefabStar, prefabBomb;
    public int p1Pos = 0;
    public int p2Pos = 0;
    public bool p1Finish = false;
    public bool p2Finish = false;
    private bool isWaiting = false;
    [SerializeField] PieceSelecter ps;

    private PlayState playState = PlayState.Player1WaitForMove;
    public void Start()
    {
        ps = FindObjectOfType<PieceSelecter>();


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

        bomb1.transform.position += Vector3.back;
        bomb2.transform.position += Vector3.back;
        bomb3.transform.position += Vector3.back;
        bomb4.transform.position += Vector3.back;
        star1.transform.position += Vector3.back;
        star2.transform.position += Vector3.back;
        star3.transform.position += Vector3.back;
        star4.transform.position += Vector3.back;
        
    }   

    public void Update()
    {
        p1Pos = Mathf.Min(p1Pos, 61);
        p2Pos = Mathf.Min(p2Pos, 61);

        if(((Player1.transform.position == LevelGenerator.tiles[6].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[20].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[40].transform.position)|| 
            (Player1.transform.position == LevelGenerator.tiles[56].transform.position)) && !isWaiting)
        {
            //StartCoroutine(Wait(MovePlayer1)); delegate
            p1Pos = 0;
            Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
        }

       if(((Player2.transform.position == LevelGenerator.tiles[6].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[20].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[40].transform.position)|| 
            (Player2.transform.position == LevelGenerator.tiles[56].transform.position)) && !isWaiting)
        {
            //StartCoroutine(Wait());
            p2Pos = 0;
            Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position; 
        }


        if(((Player1.transform.position == LevelGenerator.tiles[3].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[21].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[37].transform.position)|| 
            (Player1.transform.position == LevelGenerator.tiles[45].transform.position)) && !isWaiting)
        {
            //StartCoroutine(Wait());
            p1Pos += 2;
            Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position; 
        }

        if(((Player2.transform.position == LevelGenerator.tiles[3].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[21].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[37].transform.position)|| 
            (Player2.transform.position == LevelGenerator.tiles[45].transform.position)) && !isWaiting)
        {
            //StartCoroutine(Wait());
            p2Pos += 2;
            Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position; 
        }

        if(Player1.transform.position == LevelGenerator.tiles[0].transform.position)
        {
            Player1.transform.position -= new Vector3(2.5f, 0, 0); 
        }
        else if(Player2.transform.position == LevelGenerator.tiles[0].transform.position)
        {
            Player2.transform.position += new Vector3(2.5f, 0, 0);
        }


        if(playState == PlayState.Player1WaitForMove){
            p1Turn();
        }
        else if(playState == PlayState.Player1Moving && !isWaiting){
            //StartCoroutine(Wait());
            MovePlayer1();
        }
        else if(playState == PlayState.Player2WaitForMove){
            p2Turn();
        }
        else if(playState == PlayState.Player2Moving && !isWaiting){
            //StartCoroutine(Wait());
            MovePlayer2();
        }

        if(p1Pos == 62){
            p1Finish = true; 
        }

        if(p2Pos == 62){
            p2Finish = true;
        }
    }

    void p1Turn()
    {
        if(ps.p1 == 1){
            gris.SetActive(true);}
        else{gris.SetActive(false);}

        if(ps.p1 == 2){
            hest.SetActive(true);}
        else{hest.SetActive(false);}

        if(ps.p1 == 3){
            kanin.SetActive(true);}
        else{kanin.SetActive(false);}

        if(ps.p1 == 4){
            hund.SetActive(true);}
        else{hund.SetActive(false);}
    }

    void p2Turn()
    {
        if(ps.p2 == 1){
            gris.SetActive(true);}
        else{gris.SetActive(false);}

        if(ps.p2 == 2){
            hest.SetActive(true);}
        else{hest.SetActive(false);}

        if(ps.p2 == 3){
            kanin.SetActive(true);}
        else{kanin.SetActive(false);}

        if(ps.p2 == 4){
            hund.SetActive(true);}
        else{hund.SetActive(false);}
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

    private IEnumerator Wait(Action cmd)
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        cmd();
        isWaiting = false;
        
    }
}
