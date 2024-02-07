using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;

    int gw = 10;
    int gh = 10;
    int w = 10;
    int h = 5;

    
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
            for(int x = 0; x < map.width; x++)
            {
                int xPos = x;
                if(y % 2 == 1) {
                    xPos = map.width - x;
                }
                int num = y * map.width + x;
                GenerateTile(xPos, y, num);
            }
         }
    }
    void GenerateTile(int x, int y,int tileNum)
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
                Vector2 position = new Vector2((x*2)-32, (y*8)-50);
                //Instantiate(colorMapping.prefab, position, Quaternion.identity, transform).GetComponentInChildren<TMP_Text>()
                GameObject box = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform); 
                box.GetComponentsInChildren<SpriteRenderer>()[1].flipX = true;
                TMP_Text text = box.GetComponent<TMP_Text>();
                box.GetComponent<SpriteRenderer>().color = Color.white;
                if(tileNum%2==1)
                {
                    print(tileNum);
                    box.GetComponent<SpriteRenderer>().color = Color.red;
                }
                if(text != null)
                    text.text = tileNum.ToString();
            }
        }
    }
}
