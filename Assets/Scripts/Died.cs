using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : MonoBehaviour
{
    public void Dissappear()
    {
        gameObject.SetActive(false);
    }
}
