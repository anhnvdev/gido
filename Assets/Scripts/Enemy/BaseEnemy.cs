
using UnityEngine;
using DG.Tweening;

public abstract class BaseEnemy : MonoBehaviour, IKnockable
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    protected Vector2 axis;
    protected bool isDead = false;

    protected Animator animator;
    protected BoxCollider2D boxCollider;

    // Update is called once per frame
    protected void Moving()
    {
        if (isDead) return;
        animator.Play("Run");
        axis.x = speed;
        axis.y = rb.velocity.y;
        rb.velocity = axis;
    }
    protected void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
    }
    protected void DeadBySlam()
    {
        isDead = true;
        animator.Play("Dead");
        rb.bodyType = RigidbodyType2D.Static;
        boxCollider.enabled = false;
        Invoke("Dead", 0.5f);
    }
    protected void DeadByHit()
    {
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        boxCollider.enabled = false;
        this.transform.DOJump(new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z), 3f, 1, 3f);
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
        Invoke("Dead", 3.1f);
    }
    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LandLimit")) CheckRangeTerrain();
    }
    protected virtual void CheckRangeTerrain()
    {
    }
    public void KnockUp()
    {
        DeadByHit();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        if (collision.gameObject.CompareTag("Player")&& !isDead && normal.y < 0)
        {
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, 10f);
            DeadBySlam();
            return;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DeadByHit();
            return;
        }
        if (normal.x != 0 && (normal.y < 1 && normal.y > -1))
        {
            Flip();
            return;
        }
    }
}
