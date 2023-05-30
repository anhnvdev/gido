using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRunAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] spr;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    public IEnumerator ChangeSprite(float delay, bool loop)
    {
        if(index >= spr.Length) {
            if (loop == false)
                yield break;
            else
            {
                index = 0;
            }
                
        }
        spriteRenderer.sprite = spr[index];
        yield return new WaitForSeconds(delay);
        index++;
        StartCoroutine(ChangeSprite(delay, loop));
    }
}
