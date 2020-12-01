using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int[,] mapGrid;
    int mapSizeX = 20;
    int mapSizeY = 12;
    public Vector2 pos;
    public int xPos;
    public int yPos;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        pos = transform.position;
        xPos = (int) pos.x;
        yPos = (int) pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMapData()
    {
        //Allocate map tiles
        mapGrid = new int[mapSizeX, mapSizeY];

        //initialize map to be grass
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                mapGrid[x, y] = 0;
            }
        }
    }
}
