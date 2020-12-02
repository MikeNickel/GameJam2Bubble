using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnBasedCombat : MonoBehaviour
{
    public InitialScreen initWin;
    public CombatScreen fWin;

    //player stats
    public int playerHp;
    public int playerArmor;
    public int playerAttack;
    //for status window
    public Text pHp;
    public Text pAr;
    public Text pAt;

    //enemy stats
    int enemyAttack=2;
    int enemyArmor=2;
    int enemyHp=8;
    //enemy status window
    public Text eHp;
    public Text eAr;
    public Text eAt;

    void Start()
    {
        playerHp = PlayerPrefs.GetInt("hp");
        playerArmor = PlayerPrefs.GetInt("armor");
        playerAttack = PlayerPrefs.GetInt("attack");
    }

    
    void Update()
    {
        //player window
        pHp.text = ("Health = " + playerHp + "/10");
        pAr.text = ("Armor = " + playerArmor);
        pAt.text = ("Attack = " + playerAttack);

        //enemy window
        eHp.text = ("Health = " + enemyHp + "/8");
        eAr.text = ("Armor = " + enemyArmor);
        eAt.text = ("Attack = " + enemyAttack);

    }

    public void Fight()
    {
        initWin.DeActivate();
        fWin.Activate();
    }

    public void Back()
    {
        fWin.DeActivate();
        initWin.Activate();
    }

    public void Flee()
    {
        SceneManager.LoadScene("Overworld");
    }
}
