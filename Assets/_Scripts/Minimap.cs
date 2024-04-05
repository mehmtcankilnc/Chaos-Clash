using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private void LateUpdate()
    {
        Vector3 newPosition = player.position;

        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
        newPosition = new Vector3(clampedX, clampedY, -10);

        transform.position = newPosition;
    }
}
