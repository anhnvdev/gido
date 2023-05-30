using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.Instance.OnPlayerLevelCompleted();
        }
    }
}
