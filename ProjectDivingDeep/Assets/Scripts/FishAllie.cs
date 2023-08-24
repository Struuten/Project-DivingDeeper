using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAllie : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    [SerializeField] float swimingSpeed;
    [SerializeField] float idleSwimingSpeed;

    PlayerMovmet playerMovmet;
    PlayerHitpoints playerHitpoints;

    bool idle = true;
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

            idle = false;
        }
        else if (!idle && collision.tag == "Allie")
        {
            Destroy(gameObject);
        }
        else if (idle && collision.tag == "Allie")
        {
            Transform player;

            player = collision.transform.parent;

            playerMovmet = player.GetComponent<PlayerMovmet>();
            playerHitpoints = player.GetComponent <PlayerHitpoints>();

            playerMovmet.SetSwimingSpeed(swimingSpeed);
            player.transform.position = attachPoint.position;
            transform.SetParent (player.transform, true);

            idle = false;
        }
        else
        {
            if (playerMovmet != null)
            {
                playerMovmet.ResetSwimingSpeed();
                playerHitpoints.TakeDamage();
            }

            if (collision.tag == "Obstacle" && !idle)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

    }

    void Update()
    {
        IdleSwim();
    }

    private void IdleSwim()
    {
        if (idle)
        {
            transform.Translate(0, -MathF.Abs(idleSwimingSpeed * Time.deltaTime), 0);
        }
        return;
    }
}
