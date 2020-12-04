using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummonBoss : MonoBehaviour
{
    Vector2 pos;
    public int xPos;
    public int yPos;
    public Player other;
    public int playerPosX;
    public int playerPosY;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        xPos = (int)pos.x;
        yPos = (int)pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosX = other.GetXPos();
        playerPosY = other.GetYPos();
        //complete mobs
        if (playerPosX == xPos && playerPosY == yPos && TurnBasedCombat.victory == false)
        {
            SceneManager.LoadScene("BossScene");
        }
        else if (playerPosX == xPos && playerPosY == yPos && TurnBasedCombat.victory == true)
        {
            Died();
            TurnBasedCombat.victory = false;
            Enemy.enemiesDefeated++;
            Debug.Log("Enemies defeated: " + Enemy.enemiesDefeated);
            Enemy.bossBeat = true;
        }
        else
        {
            //do nothing
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }

    public void Died()
    {
        if (PlayerPrefs.GetInt("whereX") == xPos && PlayerPrefs.GetInt("whereY") == yPos)
        {
            Destroy(gameObject);
        }
    }
}
