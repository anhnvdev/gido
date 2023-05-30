using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    FrameRunAnimation frameAnim;
    BoxCollider2D boxCollider;
    private void Start()
    {
        frameAnim= GetComponent<FrameRunAnimation>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        StartCoroutine(frameAnim.ChangeSprite(0.2f, true));
        boxCollider.enabled= false;
        PlayerInventory.Instance.SetCheckPoint(this.transform.position);
        SaveLoadData.Instance.SaveData();
    }
}
