using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Player plyr;

    public Text ownedBG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ownedBG.text = ("Owned: " + Player.bubbleGum);
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
}
