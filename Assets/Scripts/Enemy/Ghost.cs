using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    float disapearCooldown = 4f;
    bool isDisapear;
    [SerializeField] float farX = 4f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        this.speed = -1.0f;
        StartCoroutine(DisapearCooldown(disapearCooldown));
    }
    void FixedUpdate()
    {
        this.MovingSelf();
        Apear();
        Fliping();
    }
    void MovingSelf()
    {
        if (isDead) return;
        axis.x = speed;
        axis.y = rb.velocity.y;
        rb.velocity = axis;
        if (isDisapear) return;
        animator.Play("Run");
    }
    void Disapear()
    {
        if(isDead) return;
        isDisapear= true;
        animator.Play("Disapear");
    }
    void Apear()
    {
        if ((isDisapear) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) { 
            isDisapear = false;
        }
    }
    void Fliping()
    {
        if (farX <= 0)
        {
            Flip();
            farX = 4f;
        }
        else farX -= 0.01f;
    }
    IEnumerator DisapearCooldown(float cd) {
        yield return new WaitForSeconds(cd);
        Disapear();
        StartCoroutine(DisapearCooldown(cd));
    }
}
