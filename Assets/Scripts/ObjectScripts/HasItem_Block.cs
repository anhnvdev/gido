using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasItem_Block : BaseBlock
{
    [SerializeField] GameObject item;
    [SerializeField] int itemCount = 10;
    protected override void OnBroken()
    {
        if (itemCount <= 0) return;
        BlockJumpUp();
        itemCount--;   
        PlayerInventory.Instance.FruitChange(1);
        GameObject apple = ObjectPooling.SharedInstance.GetPooledObject();
        if(apple != null)
        {
            apple.transform.position = this.transform.position;
            apple.SetActive(true);
        }
    }
}
