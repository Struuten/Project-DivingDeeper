using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoints : MonoBehaviour
{
    int hitpoints = 2;

    public void TakeDamage()
    {
        hitpoints--;
        if (hitpoints <= 0)
        {
            Debug.Log("Dieeee");
        }
        Debug.Log("Hitpoints left: " + hitpoints);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }
}
