using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


public class ItemTrigger : MonoBehaviour
{
/*
    [SerializeField] private ItemData itemData;
    [SerializeField] private Transform spawnPoint;

    private GameObject currentItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("RightHand") &&
            !other.CompareTag("LeftHand"))
            return;

        if (currentItem != null)
            return;

        SpawnItem();
    }

    void SpawnItem()
    {
        currentItem =
            ShoppingManager.Instance.SpawnItem(
                itemData,
                spawnPoint);

        GrabItem item =
            currentItem.GetComponent<GrabItem>();

        item.Initialize(this);
    }

    public void ItemTaken()
    {
        currentItem = null;

        Invoke(nameof(SpawnItem),0.3f);
    }*/
    /*
    [SerializeField] private ItemData itemData;
    [SerializeField] private ShoppingManager shoppingManager;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInteraction player =
            other.GetComponent<PlayerInteraction>();

        if (player == null)
            return;

        player.SetCurrentItem(this);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInteraction player =
            other.GetComponent<PlayerInteraction>();

        if (player == null)
            return;

        player.ClearCurrentItem();
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    [SerializeField] private InputActionReference grabAction;

    private bool canSpawn = true;
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("RightHand") && !other.CompareTag("LeftHand"))
            return;

        if (!canSpawn)
            return;

        if (grabAction.action.WasPressedThisFrame())
        {
            shoppingManager.SpawnItem(itemData);
            canSpawn = false;
        }

    }       

    private void OnTriggerExit(Collider other)
    {
            if (other.CompareTag("RightHand"))
            canSpawn = true;

            if (other.CompareTag("LeftHand"))
            canSpawn = true;
    }

    private void OnEnable()
    {
        grabAction.action.Enable();
    }

    private void OnDisable()
    {
        grabAction.action.Disable();
    }*/
}
