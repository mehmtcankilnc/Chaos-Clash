using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        Vector3 desiredPosition = target.position + offset;

        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
        desiredPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        transform.position = desiredPosition;
    }
}