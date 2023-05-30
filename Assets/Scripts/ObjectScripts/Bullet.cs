using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int maxHitCount = 3;
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) Destroy(this.gameObject);
        if (maxHitCount <= 0) Destroy(this.gameObject);
        maxHitCount -= 1;
    }
}
