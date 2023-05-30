using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AngryPig : BaseEnemy
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        this.speed = -1;
    }
    void FixedUpdate()
    {
        this.Moving();
    }
    protected override void Dead()
    {
        base.Dead();
    }
    protected override void CheckRangeTerrain()
    {
        this.Flip();
    }
}
