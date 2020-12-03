using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Player plyr;

    //update texts
    public Text ownedBG;
    public Text swordStock;
    public Text swordOwned;
    public Text armorStock;
    public Text armorOwned;


    //bools for is bought sword and armor
    public static bool sword = false;
    public static bool armor = false;

    public Sword swd;
    public Armor amr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ownedBG.text = ("Owned: " + Player.bubbleGum);
        if(sword == false)
        {
            swordStock.text = ("In stock: 1");
            swordOwned.text = ("Do not own");
        }
        else
        {
            swordStock.text = ("In stock: 0");
            swordOwned.text = ("Proud owner!");
            swd.Activate();
        }
        if(armor == false)
        {
            armorStock.text = ("In stock: 1");
            armorOwned.text = ("Do not own");
        }
        else
        {
            armorStock.text = ("In stock: 0");
            armorOwned.text = ("Proud owner!");
            amr.Activate();
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        plyr.MoveAway();
        Player.lockActions = false;
        gameObject.SetActive(false);
    }

    public void BuyBubbleGum()
    {
        if(Player.chewedGum > 0)
        {
            Player.bubbleGum += 1;
            Player.chewedGum -= 1;
        }
    }

    public void BuyBubbleSword()
    {
        if ((Player.chewedGum > 1) && sword == false)
        {
            Player.attack = Player.attack + 2;
            Player.chewedGum -= 2;
            sword = true;
            swd.Activate();
        }
    }

    public void BuyBubbleArmor()
    {
        if ((Player.chewedGum > 1) && armor == false)
        {
            Player.armor = Player.armor + 1;
            Player.chewedGum -= 2;
            armor = true;
            amr.Activate();
        }
    }
}
