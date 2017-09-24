using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed=10f;

    private Vector3 currentVelocity;

    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smootherPos = Vector3.SmoothDamp(transform.position, desiredPos,ref currentVelocity, smoothSpeed * Time.deltaTime);
        transform.position = smootherPos;
    }
}
