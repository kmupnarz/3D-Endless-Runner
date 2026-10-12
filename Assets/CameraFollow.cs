using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag your Player here in the Inspector
    public Vector3 offset = new Vector3(0f, 3f, -6f); // Camera offset relative to player
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}