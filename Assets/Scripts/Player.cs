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
    public int health;
    public int armor;
    public int attack;
    public int speed;
    public static int gumballs = 0;
    //int maxHealth = 10;
    //int startX;
    //int startY;
    //bool moved;
    bool fought = false;
    int foughtChecker = 0;

    //reference enemy gameobject
    public Enemy evil;


    // Start is called before the first frame update
    void Start()
    {
        //startX = xPos;
        //startY = yPos;
        GenerateMapData();

        if (TurnBasedCombat.victory == true)
        {
            xPos = PlayerPrefs.GetInt("whereX");
            yPos = PlayerPrefs.GetInt("whereY");
            transform.Translate(xPos-2, yPos-2, 0);
        }
        else
        {
            //do nothing
        }

        if (TurnBasedCombat.cameBackFromFight == true)
        {
            foughtChecker = PlayerPrefs.GetInt("foughtTheGoodFight");
        }
        else
        {
            //do nothing
        }

        //check if battled or not when starting scene.
        if (foughtChecker == 0)
        {
            fought = false;
        }
        else
        {
            fought = true;
            //check if victory or fled
        }
        //if no, then that means game start, have base stats.
        if(fought == false)
        {
            health = 10;
            armor = 1;
            attack = 3;
            speed = 2;
        }
        //otherwise, keep track of stats after last fight.
        else
        {
            health = PlayerPrefs.GetInt("fleeHp");
            armor = PlayerPrefs.GetInt("fleeArmor");
            attack = PlayerPrefs.GetInt("fleeAttack");
            speed = PlayerPrefs.GetInt("fleeSpeed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //keeping track of player stats to bring to combatscene
        PlayerPrefs.SetInt("hp", health);
        PlayerPrefs.SetInt("armor", armor);
        PlayerPrefs.SetInt("attack", attack);
        PlayerPrefs.SetInt("fastness", speed);

        //movement code
        if ((Input.GetKeyDown("down"))||(Input.GetKeyDown("s")))
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
                    PlayerPrefs.SetInt("xPs", xPos);
                    PlayerPrefs.SetInt("yPs", yPos);
                    transform.Translate(0, -1, 0);
                    //moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
        if ((Input.GetKeyDown("up"))||(Input.GetKeyDown("w")))
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
                    PlayerPrefs.SetInt("xPs", xPos);
                    PlayerPrefs.SetInt("yPs", yPos);
                    transform.Translate(0, +1, 0);
                    //moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
        if ((Input.GetKeyDown("left"))||(Input.GetKeyDown("a")))
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
                    PlayerPrefs.SetInt("xPs", xPos);
                    PlayerPrefs.SetInt("yPs", yPos);
                    transform.Translate(-1, 0, 0);
                   // moved = true;
                }
            }
            else
            {
                Debug.Log("Cannot travel out of map");
            }
        }
        if ((Input.GetKeyDown("right"))||(Input.GetKeyDown("d")))
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
                    PlayerPrefs.SetInt("xPs", xPos);
                    PlayerPrefs.SetInt("yPs", yPos);
                    transform.Translate(+1, 0, 0);
                    //moved = true;
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
        return xPos;
    }
    public int GetYPos()
    {
        return yPos;
    }
}
