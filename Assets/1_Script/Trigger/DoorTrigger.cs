using System.Collections;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private float gameplayStartDelay = 0.3f;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || triggered)
            return;

        triggered = true;
        StartCoroutine(StartShoppingRoutine());
    }

    private IEnumerator StartShoppingRoutine()
    {
        doorAnim.SetTrigger("OpenDoor");

        yield return new WaitForSeconds(gameplayStartDelay);

        AudioManager.Instance.PlayBGM();
        TimerManager.Instance.StartTimer();

        ShoppingManager.Instance.ChangeState(
            ShoppingState.Shopping);

        gameObject.SetActive(false);
    }
}