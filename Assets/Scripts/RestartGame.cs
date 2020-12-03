using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    public void Restart()
    {
        //everything to be reset
        //player
        Player.lockActions = false;
        Player.chewedGum = 0;
        Player.bubbleGum = 0;
        Player.fought = false;
        Player.foughtChecker = 0;
        Player.invOn = false;
        //enemy
        Enemy.enemiesDefeated = 0;
        Enemy.boss = false;
        //turnbasedcombat
        TurnBasedCombat.cameBackFromFight = false;
        TurnBasedCombat.victory = false;
        //others
        Shop.sword = false;
        Shop.armor = false;

//actual restart of game
SceneManager.LoadScene("TitleScreen");
    }
}
