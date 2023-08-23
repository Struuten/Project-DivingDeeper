using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovmet : MonoBehaviour
{
    [SerializeField] float velocity = 1f;
    [SerializeField] float jumpStrength;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float defaultSwimingSpeed;

    Rigidbody2D rb;
    float horizontalDirection;
    float jumpForce;
    float swimSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        swimSpeed = -Mathf.Abs(defaultSwimingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal") * velocity;
    }

    void FixedUpdate()
    {
        Move();
        Swim();
    }

    public void SetSwimingSpeed(float newSwimingSpeed)
    {
        swimSpeed = -Mathf.Abs(newSwimingSpeed);
    }

    public void ResetSwimingSpeed()
    {
        swimSpeed = -Mathf.Abs(defaultSwimingSpeed);
    }

    void Move()
    {
        rb.velocity = new Vector2(horizontalDirection * velocity, rb.velocity.y);
    }

    void Swim()
    {
        rb.velocity = new Vector2(rb.velocity.x, swimSpeed);
    }
}
