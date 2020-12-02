using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnBasedCombat : MonoBehaviour
{
    //screens
    public InitialScreen initWin;
    public CombatScreen fWin;
    public InfoScreen infoWin;

    //reference enemy script on enemy objects
    public Enemy other;

    public static bool cameBackFromFight=false;
    public static bool victory = false;

    int fought = 1;
    //player stats
    public int playerHp;
    public int playerArmor;
    public int playerAttack;
    //for status window
    public Text pHp;
    public Text pAr;
    public Text pAt;
    //where player was
    int xPos;
    int yPos;

    //enemy stats
    int enemyAttack;
    int enemyArmor;
    int enemyHp;
    //enemy status window
    public Text eHp;
    public Text eAr;
    public Text eAt;

    //attacking variable
    int damage;

    //info window message variables
    public Text damageDealt;



    void Start()
    {
        playerHp = PlayerPrefs.GetInt("hp");
        playerArmor = PlayerPrefs.GetInt("armor");
        playerAttack = PlayerPrefs.GetInt("attack");
        xPos = PlayerPrefs.GetInt("xPs");
        yPos = PlayerPrefs.GetInt("yPs");
        enemyAttack=2;
        enemyArmor=2;
        enemyHp=8;
        cameBackFromFight = false;
        victory = false;
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

    public void Attack()
    {
        fWin.DeActivate();
        infoWin.Activate();
        StartCoroutine(AttackEnemy());
    }

    private IEnumerator AttackEnemy()
    {
        //attack!
        damage = playerAttack + UnityEngine.Random.Range(-1, 1);
        damageDealt.text = ("You deal " + damage + " damage!");
        enemyHp -= damage;
        //checking if gum monster dead
        if (enemyHp <= 0)
        {
            enemyHp = 0;
            yield return new WaitForSeconds(2);
            damageDealt.text = ("You won the battle!");
            yield return new WaitForSeconds(2);
            Victory();
        }
        else
        {
            //monster alive still
            yield return new WaitForSeconds(2);
            //monster attack back
            damage = enemyAttack + UnityEngine.Random.Range(-1, 1);
            damageDealt.text = ("The gum attacks you for " + damage + " damage!");
            playerHp -= damage;
            yield return new WaitForSeconds(2);
            //back to initial window
            infoWin.DeActivate();
            initWin.Activate();
        }

    }
    public void Back()
    {
        fWin.DeActivate();
        initWin.Activate();
    }

    void Victory()
    {
        //return combat scene to original state
        infoWin.DeActivate();
        initWin.Activate();
        //say player won
        victory = true;
        cameBackFromFight = true;
        //keep track of victory variables
        PlayerPrefs.SetInt("fleeHp", playerHp);
        PlayerPrefs.SetInt("fleeArmor", playerArmor);
        PlayerPrefs.SetInt("fleeAttack", playerAttack);
        PlayerPrefs.SetInt("whereX", xPos);
        PlayerPrefs.SetInt("whereY", yPos);
        SceneManager.LoadScene("Overworld");
    }

    public void Flee()
    {
        //set the stats before fleeing
        PlayerPrefs.SetInt("fleeHp", playerHp);
        PlayerPrefs.SetInt("fleeArmor", playerArmor);
        PlayerPrefs.SetInt("fleeAttack", playerAttack);
        //set the stats after fleeing
        PlayerPrefs.SetInt("foughtTheGoodFight", fought);
        cameBackFromFight = true;
        SceneManager.LoadScene("Overworld");
    }
}
