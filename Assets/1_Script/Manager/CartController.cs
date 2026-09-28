using UnityEngine;

public class CartController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform handlePoint;
    [SerializeField] private Transform handleTarget;
    [SerializeField] private LayerMask groundLayer;

    [Header("Move")]
    [SerializeField] private float moveSmoothTime = 0.05f;
    [SerializeField] private float rotateSpeed = 8f;
    [SerializeField] private float heightOffset = 0.02f;
    [SerializeField] private float rayDistance = 5f;

    private bool pushing;

    private Vector3 handleOffset;
    private Vector3 velocity;

    public void StartPush()
    {
        if (pushing) return;

        pushing = true;

        handleOffset = transform.position - handlePoint.position;
    }

    public void StopPush()
    {
        pushing = false;
    }

    private void Update()
    {
        if (!pushing)
            return;


        Vector3 targetPos =
            handleTarget.position + handleOffset;



        if (Physics.Raycast(
            targetPos + Vector3.up * 2f,
            Vector3.down,
            out RaycastHit hit,
            rayDistance,
            groundLayer))
        {
            targetPos.y = hit.point.y + heightOffset;
        }



        transform.position =
            Vector3.SmoothDamp(
                transform.position,
                targetPos,
                ref velocity,
                moveSmoothTime);



        Quaternion targetRotation =
            Quaternion.Euler(
                0,
                player.eulerAngles.y,
                0);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime);
    }

    public Transform HandleTarget => handleTarget;
}