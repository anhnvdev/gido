using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float startPosX;
    float startPosY;
    [SerializeField] float parallaxEffect = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distanceX = (Camera.main.transform.position.x * parallaxEffect);
        float distanceY = (Camera.main.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);
    }
}
