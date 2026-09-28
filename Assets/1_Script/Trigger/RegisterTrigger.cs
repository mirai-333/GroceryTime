using UnityEngine;

public class RegisterTrigger : MonoBehaviour
{
    [SerializeField] GameObject btnFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        ShoppingManager.Instance.ChangeState(
            ShoppingState.Checkout);

        /*btnFinished.SetActive(true);
        gameObject.SetActive(false);*/
    }
}
