using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoSingleton<CameraHandle>
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0,0,-10);
    [SerializeField] private float offsetSmoothing = 1000f;
    [SerializeField] private Vector3 minValues = new Vector3(0, 0, -10);
    private Vector3 playerPosition;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if(target == null)
        {
            return;
        }
        playerPosition = target.transform.position + offset;
        Vector3 boundPosition = new Vector3(Mathf.Clamp(playerPosition.x, minValues.x, 999f),
            Mathf.Clamp(playerPosition.y, minValues.y, 999f),
            Mathf.Clamp(playerPosition.z, minValues.z, 999f));
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, offsetSmoothing * Time.deltaTime);
        transform.position = smoothPosition;
    }

}
