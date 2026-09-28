using UnityEngine;

public class InsideDoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController door;
    [SerializeField] private GameObject button;

    private void Start()
    {
        button.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!door.IsOpen)
            button.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        button.SetActive(false);
        door.Close();
    }
}