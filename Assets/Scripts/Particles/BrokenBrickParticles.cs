using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrokenBrickParticles : MonoBehaviour
{
    [SerializeField]Transform[] particlePieces = new Transform[4];
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float rangeX = 5f;
    [SerializeField] float rangeY = 5f;
    Vector2 endLeft;
    Vector2 endRight;
    // Start is called before the first frame update
    void Awake()
    {
        endLeft = new Vector2(transform.position.x - rangeX, transform.position.y - rangeY);
        endRight = new Vector2(transform.position.x + rangeX, transform.position.y - rangeY);
        for (int i = 0; i<particlePieces.Length; i++)
        {
            particlePieces[i] = transform.GetChild(i);
        }
        PiecesBloom();
    }
    private void OnEnable()
    {
        PiecesBloom();
    }
    private void OnDisable()
    {
        RePosition();
    }
    private void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
    void PiecesBloom()
    {
        particlePieces[0].DOJump(endLeft, jumpForce, 1, 1f);
        particlePieces[1].DOJump(endRight, jumpForce/2, 1, 1f);
        particlePieces[2].DOJump(endLeft, jumpForce/2, 1, 1f);
        particlePieces[3].DOJump(endRight, jumpForce, 1, 1f);
        Invoke("DisableObject", 1.1f);
    }
    void RePosition()
    {
        for (int i = 0; i < particlePieces.Length; i++)
        {
            particlePieces[i].position = this.transform.position;
        }
    }
}
