using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Burst.CompilerServices;

public abstract class BaseBlock : MonoBehaviour
{
    private float boundLevel = 0.2f;
    protected float bounceDuration = 0.2f;
    [SerializeField] GameObject brokenPieces;
    RaycastHit2D[] hit;
    protected abstract void OnBroken();
    protected void BlockJumpUp()
    {
        BlockKnockUp();
        if(transform != null)
        transform.DOJump(transform.position, boundLevel, 1, bounceDuration);
    }
    private void BlockKnockUp()
    {   float leftX = transform.position.x - transform.localScale.x/2;
        float rightX = transform.position.x + transform.localScale.x / 2;
        float topY = transform.position.y + transform.localScale.y/2;
        hit = Physics2D.LinecastAll(new Vector2(rightX, topY + boundLevel), new Vector2(leftX, topY + boundLevel));
        Debug.DrawLine(new Vector2(rightX, topY + boundLevel), new Vector2(leftX, topY + boundLevel));
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider != null)
            {
                IKnockable kn = hit[i].collider.GetComponent<IKnockable>();
                if (kn != null)
                {
                    kn.KnockUp();
                }
            }
        }
    }
    protected void BeBreak()
    {
        Instantiate(brokenPieces, transform.position, Quaternion.identity);
    }
    protected IEnumerator DestroyAfter(float seceonds)
    {
        yield return new WaitForSeconds(seceonds);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && collision.GetContact(0).normal.y > 0)
                OnBroken();
        }
}
