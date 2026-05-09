using UnityEngine;

public class PixelSnapCamera : MonoBehaviour
{
    public float pixelsPerUnit = 32f;
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 pos = target.position + offset;

        float unitsPerPixel = 1f / pixelsPerUnit;

        pos.x = Mathf.Round(pos.x / unitsPerPixel) * unitsPerPixel;
        pos.y = Mathf.Round(pos.y / unitsPerPixel) * unitsPerPixel;

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}