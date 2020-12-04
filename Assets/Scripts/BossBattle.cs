using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBattle : MonoBehaviour
{
    //screens
    public InitialScreen initWin;
    public CombatScreen fWin;
    public InfoScreen infoWin;
    public InvScreen invtor;

    //reference enemy script on enemy objects
    //public Enemy other;

    public static bool cameBackFromFight=false;
    public static bool victory = false;

    int fought = 1;
    //player stats
    public int playerHp;
    public int playerArmor;
    public int playerAttack;
    public int playerSpeed;
    //for status window
    public Text pHp;
    public Text pAr;
    public Text pAt;
    public Text pSd;
    //where player was
    int xPos;
    int yPos;

    //enemy stats
    int enemyAttack;
    int enemyArmor;
    int enemyHp;
    int enemySpeed;
    //enemy status window
    public Text eHp;
    public Text eAr;
    public Text eAt;
    public Text eSd;

    //attacking variable
    int damage;

    //info window message variables
    public Text info;



    void Start()
    {
        playerHp = PlayerPrefs.GetInt("hp");
        playerArmor = PlayerPrefs.GetInt("armor");
        playerAttack = PlayerPrefs.GetInt("attack");
        playerSpeed = PlayerPrefs.GetInt("fastness");
        xPos = PlayerPrefs.GetInt("xPs");
        yPos = PlayerPrefs.GetInt("yPs");
        enemyAttack = 5;
        enemyArmor = 2;
        enemyHp = 20;
        enemySpeed = 2;
        cameBackFromFight = false;
        victory = false;
    }

    
    void Update()
    {
        //player window
        pHp.text = ("Health = " + playerHp + "/12");
        pAr.text = ("Armor = " + playerArmor);
        pAt.text = ("Attack = " + playerAttack);
        pSd.text = ("Speed = " + playerSpeed);

        //enemy window
        eHp.text = ("Health = " + enemyHp + "/20");
        eAr.text = ("Armor = " + enemyArmor);
        eAt.text = ("Attack = " + enemyAttack);
        eSd.text = ("Speed = " + enemySpeed);

    }

    public void Fight()
    {
        initWin.DeActivate();
        fWin.Activate();
    }

    public void InventoryAccess()
    {
        initWin.DeActivate();
        invtor.Activate();
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
        damage = (playerAttack + UnityEngine.Random.Range(-1, 1)) - enemyArmor;
        info.text = ("You deal " + damage + " damage!");
        enemyHp -= damage;
        //checking if gum monster dead
        if (enemyHp <= 0)
        {
            enemyHp = 0;
            yield return new WaitForSeconds(2);
            info.text = ("You won the battle!");
            yield return new WaitForSeconds(2);
            info.text = ("You got a chewed gum!");
            yield return new WaitForSeconds(2);
            Victory();
        }
        else
        {
            //monster alive still
            yield return new WaitForSeconds(2);
            //monster attack back
            damage = (enemyAttack + UnityEngine.Random.Range(-1, 1)) - playerArmor;
            info.text = ("The gum attacks you for " + damage + " damage!");
            playerHp -= damage;
            yield return new WaitForSeconds(2);
            if (playerHp <= 0)
            {
                info.text = ("You have lost to the gum...");
                yield return new WaitForSeconds(2);
                infoWin.DeActivate();
                initWin.Activate();
                SceneManager.LoadScene("GameOverScreen");
            }
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
        PlayerPrefs.SetInt("fleeSpeed", playerSpeed);
        PlayerPrefs.SetInt("whereX", xPos);
        PlayerPrefs.SetInt("whereY", yPos);
        SceneManager.LoadScene("WinningScene");
    }

    public void Flee()
    {
        //set the stats before fleeing
        PlayerPrefs.SetInt("fleeHp", playerHp);
        PlayerPrefs.SetInt("fleeArmor", playerArmor);
        PlayerPrefs.SetInt("fleeAttack", playerAttack);
        PlayerPrefs.SetInt("fleeSpeed", playerSpeed);
        //set the stats after fleeing
        PlayerPrefs.SetInt("foughtTheGoodFight", fought);
        cameBackFromFight = true;
        SceneManager.LoadScene("Overworld");
    }

    public void UseBubbleGum()
    {
        //has bubble gum
        if (Player.bubbleGum > 0)
        {
            invtor.DeActivate();
            infoWin.Activate();
            StartCoroutine(WaitAfterGum());
        }
        //no bubble gum
        else
        {
            invtor.DeActivate();
            infoWin.Activate();
            StartCoroutine(WaitAfterNoGum());
        }
    }

    private IEnumerator WaitAfterGum()
    {
        info.text = ("You chew some gum and feel rejuvinated!");
        Player.bubbleGum -= 1;
        playerHp = 12;
        yield return new WaitForSeconds(2);
        damage = (enemyAttack + UnityEngine.Random.Range(-1, 1)) - playerArmor;
        info.text = ("The gum attacks you for " + damage + " damage!");
        playerHp -= damage;
        yield return new WaitForSeconds(2);
        if (playerHp <= 0)
        {
            info.text = ("You have lost to the gum...");
            yield return new WaitForSeconds(2);
            infoWin.DeActivate();
            initWin.Activate();
            SceneManager.LoadScene("GameOverScreen");
        }
        infoWin.DeActivate();
        initWin.Activate();
    }

    private IEnumerator WaitAfterNoGum()
    {
        info.text = ("No Gum!");
        yield return new WaitForSeconds(2);
        damage = (enemyAttack + UnityEngine.Random.Range(-1, 1)) - playerArmor;
        info.text = ("The gum attacks you for " + damage + " damage!");
        playerHp -= damage;
        yield return new WaitForSeconds(2);
        if (playerHp <= 0)
        {
            info.text = ("You have lost to the gum...");
            yield return new WaitForSeconds(2);
            infoWin.DeActivate();
            initWin.Activate();
            SceneManager.LoadScene("GameOverScreen");
        }
        infoWin.DeActivate();
        initWin.Activate();
    }
}
