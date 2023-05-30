using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Block : BaseBlock
{
    protected override void OnBroken()
    {
        BlockJumpUp();
        Invoke("BeDestroyed", this.bounceDuration/2);
    }
    private void BeDestroyed()
    {
        this.BeBreak();
        Destroy(this.gameObject);
    }
}
