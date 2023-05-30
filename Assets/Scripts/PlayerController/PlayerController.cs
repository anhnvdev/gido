using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private PlayerMovement_Create movementConfig;
    private float speed;
    private float jumpForce;
    [SerializeField] private Vector2 axis = new Vector2(0,0);
    [SerializeField] private States charState = States.Idle;
    private BoxCollider2D boxCollider;
    private bool isFacingRight = true;

    Animator animator;
    private enum States
    {
        Idle, Jumping, Falling, Running, Dead
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadComponent();
    }
    void LoadComponent()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        speed = movementConfig.speed;
        jumpForce= movementConfig.jumpForce;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (charState != States.Dead)
        {
            Movement();
            Jump();
            RunningCheck();
            FacingCheck();
            SetAnimator();
        }
    }
    void Movement()
    {
        if (charState == States.Dead) return;
        axis.x = InputManager.Instance.Axis * speed;
        axis.y = rb.velocity.y;
        rb.velocity = axis;
    }
    void Jump()
    {
        if (InputManager.Instance.IsJumpButtonDown && charState != States.Jumping && charState != States.Falling)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            charState = States.Jumping;
        }
    }
    void FallingCheck()
    {
        if (axis.y < 0 && charState == States.Jumping) charState = States.Falling;
    }
    void RunningCheck()
    {
        if (rb.velocity.x == 0 && charState != States.Jumping && charState != States.Falling) charState = States.Idle;
        else if (rb.velocity.x != 0  && charState != States.Jumping && charState != States.Falling) charState = States.Running;
    }
    void FacingCheck()
    {
        if(isFacingRight && rb.velocity.x < 0)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(!isFacingRight && rb.velocity.x > 0)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    public void Grounded()
    {
        charState = States.Idle;
    }

    private void SetAnimator()
    {
        switch(charState)
        {
            case States.Idle:
                animator.Play("Idle", 0);
                break;
            case States.Running:
                animator.Play("Run", 0);       
                break;
            case States.Jumping: 
                animator.Play("Jump", 0); 
                break;
        }
    }
    private void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        charState = States.Idle;
        animator.enabled= true;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        rb.velocity = Vector3.zero;
        boxCollider.enabled = true;
        InputManager.Instance.enabled = true;
        GameController.Instance.OnPlayerRespawn();
    }
    void Dead()
    {
        charState = States.Dead;
        InputManager.Instance.enabled = false;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Static;
        boxCollider.enabled = false;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        animator.enabled= false;
        Invoke("HeadDown", 1f);
    }
    void HeadDown()
    {
        rb.gravityScale = 1f;
        transform.DOJump(new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z), 10f, 1, 1.9f);
        Invoke("Respawn", 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && collision.GetContact(0).normal.y > 0)
        {
            Grounded();
        }
        if (collision.gameObject.CompareTag("Enemy") && collision.GetContact(0).normal.y <= 0 && collision.GetContact(0).normal.x != 0)
        {
            Dead();
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Dead();
        }
    }
}
