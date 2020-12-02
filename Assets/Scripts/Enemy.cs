using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    int[,] mapGrid;
    public int mapSizeX = 22;
    public int mapSizeY = 12;
    Vector2 pos;
    public int xPos;
    public int yPos;
    public Player other;
    public int playerPosX;
    public int playerPosY;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        pos = transform.position;
        xPos = (int) pos.x;
        yPos = (int) pos.y;

            //StartCoroutine(Hold());
    }

    // Update is called once per frame
    void Update()
    {
        //see if player runs into enemy, start combat once this happens.
        playerPosX = other.GetXPos();
        playerPosY = other.GetYPos();
        Debug.Log("player x =" + playerPosX);
        Debug.Log("player y =" + playerPosY);
        if (playerPosX == xPos && playerPosY == yPos && TurnBasedCombat.victory == false)
        {
            SceneManager.LoadScene("CombatScene");
        }
        else if(playerPosX == xPos && playerPosY == yPos && TurnBasedCombat.victory == true)
        {
            Died();
            TurnBasedCombat.victory = false;
        }
        else
        {
            //do nothing
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

    public void Died()
    {
        if (PlayerPrefs.GetInt("whereX") == xPos && PlayerPrefs.GetInt("whereY") == yPos)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Hold()
    {
        yield return new WaitForSeconds(2f);
    }
}
