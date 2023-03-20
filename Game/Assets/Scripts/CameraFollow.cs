using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minPosition, maxPosition;

    private Vector3 newPosition;
    private Vector3 boundPosition;
    private Vector3 smoothPosition;


    void FixedUpdate(){
        FollowCamera();
    }

    void FollowCamera() {
        newPosition = target.position + offset;
        boundPosition = new Vector3(
            Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y),
            Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z));

        smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

}
