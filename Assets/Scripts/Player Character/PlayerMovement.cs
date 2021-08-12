﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    InputManager inputManager;

    [SerializeField]
    private double runningSpeed = 0,swerveSpeed=0;

    private bool startRunning = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        if (inputManager.touched)
        {
            if (!startRunning)
            {
                StartRunning();
            }
        }
        if (startRunning)
        {
           // if (rb.velocity.z < (float)runningSpeed)
          //  {
                rb.velocity = new Vector3(0, 0, 5);
                PlayerControl(inputManager.direction);
           // }
            //else
               // rb.velocity += new Vector3(0, 0, -0.25f);
        }
    }

    void StartRunning()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
        startRunning = true;
    }
    void PlayerControl(float touchDirection)
    {
        float horizontalPosition = transform.position.x + touchDirection * Time.deltaTime * (float)swerveSpeed;
        horizontalPosition = Mathf.Clamp(horizontalPosition, -5.5f, 5.5f);
        transform.position = new Vector3(horizontalPosition, transform.position.y, transform.position.z);
    }


}
