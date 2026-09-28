using UnityEngine;

public class HandSnap : MonoBehaviour
{
    private Transform target;
    private bool snapped;

    public void Snap(Transform point)
    {
        target = point;
        snapped = true;
    }

    public void Release()
    {
        snapped = false;
    }

    private void LateUpdate()
    {
        if (!snapped) return;

        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}