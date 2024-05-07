using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum PlayState{
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
    public GameObject pauseButton, menyButton;
    public int p1Pos = 0;
    public int p2Pos = 0;
    public bool p1Finish = false;
    public bool p2Finish = false;
    private bool isWaiting = false;
    public bool paused = false;
    public static int startCounter = 0;
    [SerializeField] PieceSelecter ps;

    public PlayState playState = PlayState.Player1WaitForMove;
    public void Start()
    {
        startCounter++;
        Debug.Log("Start " + Time.deltaTime + "Start Counter " + startCounter);
        ps = GetComponent<PieceSelecter>();
        Debug.Log("Done1");
        
        Debug.Log("Ternary test " + ((LevelGenerator.tiles[p1Pos].transform == null) ? 1 : 2));

        Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
        Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
        playState = PlayState.Player1WaitForMove;
        Debug.Log("Done2");

        GameObject bomb1 = Instantiate(prefabBomb, LevelGenerator.tiles[6].transform.position, Quaternion.identity, transform);
        GameObject bomb2 = Instantiate(prefabBomb, LevelGenerator.tiles[20].transform.position, Quaternion.identity, transform);
        GameObject bomb3 = Instantiate(prefabBomb, LevelGenerator.tiles[40].transform.position, Quaternion.identity, transform);
        GameObject bomb4 = Instantiate(prefabBomb, LevelGenerator.tiles[56].transform.position, Quaternion.identity, transform);

        GameObject star1 = Instantiate(prefabStar, LevelGenerator.tiles[3].transform.position, Quaternion.identity, transform);
        GameObject star2 = Instantiate(prefabStar, LevelGenerator.tiles[21].transform.position, Quaternion.identity, transform);
        GameObject star3 = Instantiate(prefabStar, LevelGenerator.tiles[37].transform.position, Quaternion.identity, transform);
        GameObject star4 = Instantiate(prefabStar, LevelGenerator.tiles[45].transform.position, Quaternion.identity, transform);

        Debug.Log("Done3");

        bomb1.transform.position += Vector3.back;
        bomb2.transform.position += Vector3.back;
        bomb3.transform.position += Vector3.back;
        bomb4.transform.position += Vector3.back;
        star1.transform.position += Vector3.back;
        star2.transform.position += Vector3.back;
        star3.transform.position += Vector3.back;
        star4.transform.position += Vector3.back;

        Debug.Log("Done4");
    }   
    public void Update()
    {
        p1Pos = Mathf.Min(p1Pos, 62);
        p2Pos = Mathf.Min(p2Pos, 62);

        if(((Player1.transform.position == LevelGenerator.tiles[6].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[20].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[40].transform.position)|| 
            (Player1.transform.position == LevelGenerator.tiles[56].transform.position)) && !isWaiting)
        {
            p1Pos = 0;
            StartCoroutine(Wait(() => {
                Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position;
            }, 1f));
        }

       if(((Player2.transform.position == LevelGenerator.tiles[6].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[20].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[40].transform.position)|| 
            (Player2.transform.position == LevelGenerator.tiles[56].transform.position)) && !isWaiting)
        {
            p2Pos = 0;
            StartCoroutine(Wait(() => {
                Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
            }, 1f));
        }


        if(((Player1.transform.position == LevelGenerator.tiles[3].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[21].transform.position) || 
            (Player1.transform.position == LevelGenerator.tiles[37].transform.position)|| 
            (Player1.transform.position == LevelGenerator.tiles[45].transform.position)) && !isWaiting)
        {
            p1Pos += 2;
            StartCoroutine(Wait(() => {
                Player1.transform.position = LevelGenerator.tiles[p1Pos].transform.position; 
            }, 1f));
        }

        if(((Player2.transform.position == LevelGenerator.tiles[3].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[21].transform.position) || 
            (Player2.transform.position == LevelGenerator.tiles[37].transform.position)|| 
            (Player2.transform.position == LevelGenerator.tiles[45].transform.position)) && !isWaiting)
        {
            p2Pos += 2;
            StartCoroutine(Wait(() => {
                Player2.transform.position = LevelGenerator.tiles[p2Pos].transform.position;
            }, 1f));
             
        }

        if(Player1.transform.position == Player2.transform.position)
        {
            Player1.transform.position -= new Vector3(2.5f, 0, 0); 
            Player2.transform.position += new Vector3(2.5f, 0, 0);
        }


        if(playState == PlayState.Player1WaitForMove){
            p1Turn();
        }
        else if(playState == PlayState.Player1Moving && !isWaiting && !paused){
            StartCoroutine(Wait(MovePlayer1, 4f));
        }
        else if(playState == PlayState.Player2WaitForMove){
            p2Turn();
        }
        else if(playState == PlayState.Player2Moving && !isWaiting && !paused){
            StartCoroutine(Wait(MovePlayer2, 4f));
        }

        if(p1Pos == 62){
            p1Finish = true; 
        }

        if(p2Pos == 62){
            p2Finish = true;
        }

        if(p1Finish)
        {
            SceneManager.LoadScene(2);
        }
        else if(p2Finish)
        {
            SceneManager.LoadScene(3);
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
        StartCoroutine(Wait(() => {
                print("Moved");
            }, 2f));
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

    public void Pause()
    {
        if(paused){
            paused = false;
            pauseButton.transform.position = new Vector3(-48.8f, 23.8f, -8.53f);
            pauseButton.transform.localScale = new Vector3(1, 1, 1);
            menyButton.SetActive(false);
        }
        else if(!paused){
            paused = true;
            pauseButton.transform.position = new Vector3(0, 0, -8.53f);
            pauseButton.transform.localScale = new Vector3(5, 5, 1);
            menyButton.SetActive(true);
        }
    }

    public void Meny()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator Wait(Action cmd, float time)
    {
        isWaiting = true;
        yield return new WaitForSeconds(time);
        cmd();
        isWaiting = false;
        
    }
}
