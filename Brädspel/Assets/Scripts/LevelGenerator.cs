using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel1();

        if(tag == "Block")
        {
            transform.position = new Vector3(0, 0, 1);
        }
    }

    void GenerateLevel1()
    {
        for(int y = 0; y < map.height; y++)
        {
            int x = 0;
            for(; x < map.width; x++)
            {
                int xPos = x;
                if(y % 2 == 1) {
                    xPos = map.width - x - 1;
                }
                Color color = Color.white;
                //Color[] colors = new Color[]{new Color(0.0f,0.2f,0.7f),new Color(1.0f,0.2f,0.7f)};
                //color = colors[(xPos+y%4)%4];
               
                if(y == 0) {
                    if(xPos%4 == 0){
                        color = new Color(1.0f,1.0f,0.5f); //yellow
                    }
                    if(xPos%4 == 1){
                        color = new Color(0.5f,0.75f,1.0f); //blue
                    }
                    if(xPos%4 == 2){
                        color = new Color(1.0f,0.4f,0.5f); //red
                    }
                    if(xPos%4 == 3){
                        color = new Color(0.9f,0.6f,1.0f); //purple
                    }
                }
                if(y == 1) {
                    if(xPos%4 == 3){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == 0){
                        color = new Color(0.5f,0.75f,1.0f);
                    }
                    if(xPos%4 == 1){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == 2){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                }

                if(y == 2) {
                    if(xPos%4 == 0){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == 1){
                        color = new Color(0.5f,0.75f,1.0f); 
                    }
                    if(xPos%4 == 2){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == 3){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                }
                if(y == 3) {
                    if(xPos%4 == 1){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == 2){
                        color = new Color(0.5f,0.75f,1.0f);
                    }
                    if(xPos%4 == 3){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == 0){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                }
                if(y == 4) {
                    if(xPos%4 == 2){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == 3){
                        color = new Color(0.5f,0.75f,1.0f);
                    }
                    if(xPos%4 == 0){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == 1){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                }
                if(y == 5) {
                    if(xPos%4 == 3){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == 0){
                        color = new Color(0.5f,0.75f,1.0f);
                    }
                    if(xPos%4 == 1){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == 2){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                }
                if(y == 6) {
                    if(xPos%4 == 0){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == 1){
                        color = new Color(0.5f,0.75f,1.0f);
                    }
                    if(xPos%4 == 2){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == 3){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                }

                /*colorNum = Mathf.Clamp(colorNum, 0, 3);

                    if(xPos%4 == colorNum){
                        color = new Color(1.0f,1.0f,0.5f);
                    }
                    if(xPos%4 == colorNum+1){
                        color = new Color(0.5f,0.75f,1.0f);
                    }
                    if(xPos%4 == colorNum+2){
                        color = new Color(1.0f,0.4f,0.5f);
                    }
                    if(xPos%4 == colorNum+3){
                        color = new Color(0.9f,0.6f,1.0f);
                    }
                    if(colorNum == 3){
                        colorNum = 0;
                    }*/

                int num = y * map.width + x;
                GenerateTile(xPos, y, num, color); 
            }

         }
    }
    void GenerateTile(int x, int y,int tileNum, Color color)
    {
        Color pixelColor = map.GetPixel(x, y);
        print(pixelColor);

        if(pixelColor.a == 0)
        {
            //The pixel is transparrent. Let's igonre it
            //return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings){
            print(colorMapping.color.Equals(pixelColor));
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2((x*11)-45, (y*6)-20);
                //Instantiate(colorMapping.prefab, position, Quaternion.identity, transform).GetComponentInChildren<TMP_Text>()
                GameObject box = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform); 
                TMP_Text text = box.GetComponentInChildren<TMP_Text>();

                if(y % 2 == 1){
                    box.GetComponentsInChildren<SpriteRenderer>()[1].flipX = true;

                }

                if(y % 2 == 0 && x % 9 == 8)
                {
                    box.GetComponentsInChildren<SpriteRenderer>()[1].transform.Rotate(0,0,90f);
                    box.GetComponentsInChildren<SpriteRenderer>()[1].transform.localScale = new Vector3(0.15f,0.15f,1f);
                }
                if(y % 2 == 1 && x % 9 == 0)
                {
                    box.GetComponentsInChildren<SpriteRenderer>()[1].transform.Rotate(0,0,-90f);
                    box.GetComponentsInChildren<SpriteRenderer>()[1].transform.localScale = new Vector3(0.15f,0.15f,1f);
                }
                if(tileNum == 62 || tileNum == 0)
                {
                    Destroy(box.GetComponentsInChildren<SpriteRenderer>()[1]);
                }

                

                box.GetComponent<SpriteRenderer>().color = color;
                
                if(text != null)
                    text.text = tileNum.ToString();
            }
        }
    }
}
