using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    public ItemData ItemData => itemData;

    public bool IsAdded { get; private set; }

    public void MarkAsAdded()
    {
        IsAdded = true;
    }

}