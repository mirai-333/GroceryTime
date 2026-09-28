using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject button;


    bool isOpen;

    public void Open()
    {
        if (isOpen) return;

        animator.ResetTrigger("Close");
        animator.SetTrigger("Open");
        isOpen = true;

        button.SetActive(false);

        AudioManager.Instance.PlayFridgeOpen();


    }

    public void Close()
    {
        if (!isOpen) return;

        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
        isOpen = false;

        AudioManager.Instance.PlayFridgeClose();

    }

    public bool IsOpen => isOpen;
}