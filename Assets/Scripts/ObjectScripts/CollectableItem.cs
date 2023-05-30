using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FrameRunAnimation))]
public class CollectableItem : MonoBehaviour, IKnockable
{
    FrameRunAnimation frameRun;
    [SerializeField] GameObject collectedEffect;
    private void Start()
    {
        frameRun = GetComponent<FrameRunAnimation>();
        StartCoroutine(frameRun.ChangeSprite(0.2f, true));
    }
    void BeCollected()
    {
        PlayerInventory.Instance.FruitChange(1);
        Instantiate(collectedEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BeCollected();
        }
    }
    public void KnockUp()
    {
        BeCollected();
    }
}
