using UnityEngine;
using UnityEngine.InputSystem;

public class HandleTrigger : MonoBehaviour
{
    [SerializeField] private CartController cart;

    [Header("Input")]
    [SerializeField] private InputActionReference rightTrigger;
    [SerializeField] private InputActionReference leftTrigger;

    private Transform rightHand;
    private Transform leftHand;

    private void OnEnable()
    {
        rightTrigger.action.Enable();
        leftTrigger.action.Enable();
    }

    private void OnDisable()
    {
        rightTrigger.action.Disable();
        leftTrigger.action.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
            rightHand = other.transform;

        if (other.CompareTag("LeftHand"))
            leftHand = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightHand"))
            rightHand = null;

        if (other.CompareTag("LeftHand"))
            leftHand = null;

        if (rightHand == null && leftHand == null)
            cart.StopPush();
    }

    private void LateUpdate()
    {
        Transform activeHand = null;

        if (rightHand != null && rightTrigger.action.IsPressed())
            activeHand = rightHand;

        else if (leftHand != null && leftTrigger.action.IsPressed())
            activeHand = leftHand;

        if (activeHand == null)
        {
            cart.StopPush();
            return;
        }

        //--------------------------
        // 少し前にHandleTargetを置く
        //--------------------------

        Vector3 target =
            activeHand.position
            + activeHand.forward * 0.08f;

        //--------------------------
        // HandleTargetを少し遅らせる
        //--------------------------

        cart.HandleTarget.position =
            Vector3.Lerp(
                cart.HandleTarget.position,
                target,
                15f * Time.deltaTime);

        cart.HandleTarget.rotation =
            Quaternion.Slerp(
                cart.HandleTarget.rotation,
                activeHand.rotation,
                15f * Time.deltaTime);

        cart.StartPush();
    }
}