using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAllay : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    [SerializeField] float swimingSpeed;

    PlayerMovmet playerMovmet;
    PlayerHitpoints playerHitpoints;
    bool isAttached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.tag == "Player")
        {
            playerMovmet = collision.GetComponent<PlayerMovmet>();
            playerHitpoints = collision.GetComponent<PlayerHitpoints>();

            playerMovmet.SetSwimingSpeed(swimingSpeed);

            collision.transform.position = attachPoint.position;
            transform.SetParent(collision.transform, true);

            isAttached = true;
        }
        else
        {
            Debug.Log("Entered else");
            if (playerMovmet != null)
            {
                playerMovmet.ResetSwimingSpeed();
                isAttached = false;
                playerHitpoints.TakeDamage();
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
