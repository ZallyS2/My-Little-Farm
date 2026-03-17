using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public Transform target;
    public float pixelsPerUnit = 16f;

    void LateUpdate()
    {
        if(target == null) return;

        Vector3 pos = target.position;

        float unit = 1f / pixelsPerUnit;

        pos.x = Mathf.Round(pos.x / unit) * unit;
        pos.y = Mathf.Round(pos.y / unit) * unit;

        transform.position = new Vector3(pos.x, pos.y, -10f);
    }
}