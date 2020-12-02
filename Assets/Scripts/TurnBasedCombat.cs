using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnBasedCombat : MonoBehaviour
{
    public InitialScreen initWin;
    public CombatScreen fWin;
    public InfoScreen infoWin;

    public static bool cameBackFromFight=false;

    int fought = 1;
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

    //attacking variable
    int damage;

    //info window message variables
    public Text damageDealt;



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

    public void Attack()
    {
        fWin.DeActivate();
        infoWin.Activate();
        StartCoroutine(AttackEnemy());
    }

    private IEnumerator AttackEnemy()
    {
        damage = playerAttack + UnityEngine.Random.Range(-1, 1);
        damageDealt.text = ("You deal " + damage + " damage!");
        enemyHp -= damage;
        yield return new WaitForSeconds(2);
        damage = enemyAttack + UnityEngine.Random.Range(-1, 1);
        damageDealt.text = ("The gum attacks you for " + damage + " damage!");
        playerHp -= damage;
        yield return new WaitForSeconds(2);
        infoWin.DeActivate();
        initWin.Activate();

    }
    public void Back()
    {
        fWin.DeActivate();
        initWin.Activate();
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
