﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMechanic : MonoBehaviour
{
    private PlayerController controller;
    private InputManager im;
    public Animator anim;

    public bool isAttacking = false;

    public float upAttackDuration;
    private bool isAttackUp = false;

    public float punchAttackDuration;
    private bool isAttackpunch = false;

    public float downAttackDuration;
    private bool isAttackDown = false;

    private float attack_timer = 0f;

    [Range(0, 2000)]
    public float knockbackForce;

    private void Awake()
    {
        im = GameObject.Find("InputManager").GetComponent<InputManager>();
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!isAttacking)
        {
            // able to punch

            // if player is not moving
            if (controller.moveInput == 0f)
            {
                if (im.XisPushed(controller.PlayerNum))
                {
                    anim.Play("Blue_PlayerPunchAnim");
                    isAttacking = true;
                    isAttackpunch = true;
                }
                else if (im.YisPushed(controller.PlayerNum))
                {
                    anim.Play("Blue_PlayerUpAttackAnim");
                    isAttacking = true;
                    isAttackUp = true;
                }
                else if (im.BisPushed(controller.PlayerNum))
                {
                    anim.Play("Blue_PlayerDownAttackAnim");
                    isAttacking = true;
                    isAttackDown = true;
                }
            }    
        }
        else
        {
            if (isAttackUp)
            {
                attack_timer += Time.deltaTime;
                if (attack_timer >= upAttackDuration)
                {
                    isAttacking = false;
                    isAttackUp = false;
                    attack_timer = 0f;
                }
            }
            else if (isAttackpunch)
            {
                attack_timer += Time.deltaTime;
                if (attack_timer >= punchAttackDuration)
                {
                    isAttacking = false;
                    isAttackpunch = false;
                    attack_timer = 0f;
                }
            }
            else if (isAttackDown)
            {
                attack_timer += Time.deltaTime;
                if (attack_timer >= downAttackDuration)
                {
                    isAttacking = false;
                    isAttackDown = false;
                    attack_timer = 0f;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
    }
}