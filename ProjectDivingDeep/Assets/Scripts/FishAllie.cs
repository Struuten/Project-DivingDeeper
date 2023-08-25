using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAllie : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    [SerializeField] float swimingSpeed;
    [SerializeField] float idleSwimingSpeed;
    [SerializeField] float beginSwimDistance;

    PlayerMovmet playerMovmet;
    PlayerHitpoints playerHitpoints;
    GameObject player;

    bool idleSwiming = true;
    bool isRiding = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovmet>().gameObject;

        playerMovmet = player.GetComponent<PlayerMovmet>();
        playerHitpoints = player.GetComponent<PlayerHitpoints>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerMovmet.SetSwimingSpeed(swimingSpeed);

            collision.transform.position = attachPoint.position;
            transform.SetParent(collision.transform, true);

            idleSwiming = false;
            isRiding = true;
        }
        else if (isRiding && collision.tag == "Allie" || collision.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (!isRiding && collision.tag == "Allie" && collision.transform.parent.tag == "Player")
        {
            playerMovmet.SetSwimingSpeed(swimingSpeed);
            player.transform.position = attachPoint.position;
            transform.SetParent (player.transform, true);

            idleSwiming = false;
            isRiding = true;
        }
        else
        {
            if (transform.parent != null && transform.parent.tag == "Player")
            {
                playerMovmet.ResetSwimingSpeed();
                playerHitpoints.TakeDamage();
            }

            if (collision.tag == "Obstacle" && !idleSwiming || collision.tag == "Enemy" && !idleSwiming)
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
        if (idleSwiming && Vector2.Distance(transform.position, player.transform.position) <= beginSwimDistance)
        {
            transform.Translate(0, -MathF.Abs(idleSwimingSpeed * Time.deltaTime), 0);
        }
        return;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, beginSwimDistance);
    }
}
