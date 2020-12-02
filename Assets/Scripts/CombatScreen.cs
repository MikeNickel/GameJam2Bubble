using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScreen : MonoBehaviour
{
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }
}
