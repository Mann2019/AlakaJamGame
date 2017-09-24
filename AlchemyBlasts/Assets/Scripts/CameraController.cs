using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed=10f;

    private Vector3 currentVelocity;

    private void LateUpdate()
    {
        if(target)
        {
            Vector3 pos = new Vector3(target.position.x, 11f, -10f);
            Vector3 desiredPos = pos + offset;
            Vector3 smootherPos = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, smoothSpeed * Time.deltaTime);
            transform.position = smootherPos;
        }
    }
}
