using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPointDebug : MonoSingleton<VisualPointDebug>
{
    public GameObject pre;
    public void DrawObject(Vector2 pos)
    {
        if (pre != null)
        {
            Instantiate(pre, pos, Quaternion.identity);
        }
    }
}
