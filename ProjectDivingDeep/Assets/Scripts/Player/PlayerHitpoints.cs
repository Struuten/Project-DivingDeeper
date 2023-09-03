using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoints : MonoBehaviour
{
    [SerializeField] ParticleSystem blood;
    [SerializeField] int bloodEmssionDie = 100;
    [SerializeField] Canvas dieCanvas;
    int hitpoints = 2;

    bool isAttached = false;

    public void TakeDamage()
    {
        hitpoints--;
        blood.Play();
        if (hitpoints <= 0)
        {
            var emission = blood.emission;
            emission.rateOverTime = bloodEmssionDie;
            blood.Play();
            Time.timeScale = 0;
            dieCanvas.gameObject.SetActive(true);
        }
        Debug.Log("Hitpoints left: " + hitpoints);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAttached) return;
        TakeDamage();
        
        if (collision.transform.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
}
