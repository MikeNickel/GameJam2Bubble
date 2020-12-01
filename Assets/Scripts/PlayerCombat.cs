using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        playerHp = PlayerPrefs.GetInt("hp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
