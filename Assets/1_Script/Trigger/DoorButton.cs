using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private DoorController door;

    public void OpenDoor()
    {
        door.Open();

        AudioManager.Instance.PlayButton();

    }
}