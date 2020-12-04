using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvScreenBoss : MonoBehaviour
{
    public Text ownBG;
    public Text info;

    public BossBattle play;
    public InfoScreen inf;
    public InitialScreen initWin;


    // Update is called once per frame
    void Update()
    {
        ownBG.text = ("Bubble Gum: " + Player.bubbleGum);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }

    //player chooses to use a bubblegum to heal in combat
    public void UseBubbleGum()
    {
        play.UseBubbleGum();
    }

    public void Back()
    {
        DeActivate();
        initWin.Activate();
    }

}
