using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float coolDown = 2f;
    [SerializeField] float bulletForceX = 15f;
    [SerializeField] float bulletForceY = 5f;
    Transform playerTransform;
    private float localScaleX;

    private void Start()
    {
        playerTransform = transform.parent.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
        CoolDown();
    }
    void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.F) || UIManager.Instance.FireButtonDown)  && PlayerInventory.Instance.Fruit > 9 && coolDown <= 0) {
            coolDown = 2f;
            PlayerInventory.Instance.FruitChange(-10);
            GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = bulletObj.GetComponent<Rigidbody2D>();
            localScaleX = playerTransform.localScale.x;
            if(localScaleX > 0)
            rb.velocity = new Vector2(bulletForceX, -bulletForceY);
            else rb.velocity = new Vector2(-bulletForceX, -bulletForceY);
        }
    }
    void CoolDown()
    {
        if (coolDown <= 0) return;
        coolDown -= 1f * Time.deltaTime;
    }
}
