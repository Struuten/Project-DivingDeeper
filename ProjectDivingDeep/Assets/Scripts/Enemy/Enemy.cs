using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float routeSpeed;
    [SerializeField] Transform endPoint;

    [SerializeField] float travelPercent;

    Vector2 startPosition;
    Vector2 endPosition;
    bool goingBack = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        return;
    }

    private void Start()
    {
        travelPercent = 0;
        if( endPoint != null) 
        {
            startPosition = transform.position;
            endPosition = new Vector2(endPoint.position.x, endPoint.position.y);

            StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        while (true)
        {
            if (!goingBack)
            {
                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * routeSpeed;
                    transform.position = Vector2.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
                goingBack = true;
                travelPercent = 0;
            }
            if (goingBack)
            {
                transform.localScale = new Vector3(1, -1, 1);
                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * routeSpeed;
                    transform.position = Vector2.Lerp(endPosition, startPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
                goingBack = false;
                travelPercent = 0;
            }
        }
    }
}
