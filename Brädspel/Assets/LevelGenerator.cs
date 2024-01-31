using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        /*for(int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }*/

        for(int y = 0; y < map.height; y++)
        {
            for(int x = 0; x < map.width; x++)
            {
                GenerateTile(x, y);
             }
         }
    }
    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            //The pixel is transparrent. Let's igonre it
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings){
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x-32, y-30);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
