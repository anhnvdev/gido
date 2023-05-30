using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpingCollectedItem : MonoBehaviour
{
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float lifeTime = 0.65f;
    // Start is called before the first frame update
    void Awake()
    {
        transform.DOJump(new Vector3(transform.position.x,transform.position.y + 2.8f, transform.position.z), jumpForce, 1, lifeTime);
        Invoke("Destroy", lifeTime + 0.01f);
    }
    private void OnEnable()
    {
        transform.DOJump(new Vector3(transform.position.x, transform.position.y + 2.8f, transform.position.z), jumpForce, 1, lifeTime);
        Invoke("Destroy", lifeTime + 0.01f);
    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
