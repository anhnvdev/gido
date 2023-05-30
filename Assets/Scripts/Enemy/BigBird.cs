using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBird : BaseEnemy
{
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            boxCollider = GetComponent<BoxCollider2D>();
            this.speed = -1.0f;
        }
    void Update()
    {
        this.Moving();
    }
}
