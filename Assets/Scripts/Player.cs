using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int mapSizeX = 22;
    public int mapSizeY = 12;
    int[,] mapGrid;
    public int xPos = 2;
    public int yPos = 2;
    public int health = 10;
    public int armor = 1;
    public int attack = 3;
    int maxHealth = 10;
    int startX;
    int startY;
    bool moved;


    // Start is called before the first frame update
    void Start()
    {
        startX = xPos;
        startY = yPos;
        GenerateMapData();
    }

    // Update is called once per frame
    void Update()
    {
        moved = false;

        PlayerPrefs.SetInt("hp", health);
        PlayerPrefs.SetInt("armor", armor);
        PlayerPrefs.SetInt("attack", attack);

        if (Input.GetKeyDown("down"))
        {
            if (yPos > 1)
            {
                yPos -= 1;
                if (yPos < 0)
                {
                    yPos = +1;
                }
                else if (mapGrid[xPos, yPos] == 2)
                {
                    yPos += 1;
                }
                else
                {
                    transform.Translate(0, -1, 0);
                    moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
        if (Input.GetKeyDown("up"))
        {
            if (yPos < mapSizeY - 2)
            {
                yPos += 1;
                if (yPos > (mapSizeY - 1))
                {
                    yPos = +1;
                }
                else if (mapGrid[xPos, yPos] == 2)
                {
                    yPos -= 1;
                }
                else
                {
                    transform.Translate(0, +1, 0);
                    moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (xPos > 1)
            {
                xPos -= 1;
                if (xPos < 0)
                {
                    xPos = +1;
                }
                else if (mapGrid[xPos, yPos] == 2)
                {
                    xPos += 1;
                }
                else
                {
                    transform.Translate(-1, 0, 0);
                    moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
        if (Input.GetKeyDown("right"))
        {
            if (xPos < mapSizeX - 2)
            {
                xPos += 1;
                if (xPos > (mapSizeX - 1))
                {
                    xPos = -1;
                }
                else if (mapGrid[xPos, yPos] == 2)
                {
                    xPos -= 1;
                }
                else
                {
                    transform.Translate(+1, 0, 0);
                    moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
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

    public int GetXPos()
    {
        Debug.Log("Getting x position");
        return xPos;
    }
    public int GetYPos()
    {
        return yPos;
    }
}
