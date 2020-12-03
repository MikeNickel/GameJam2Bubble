using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementScreen : MonoBehaviour
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
