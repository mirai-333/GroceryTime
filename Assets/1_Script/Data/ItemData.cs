using UnityEngine;

public enum ItemType
{
    Need,
    Unnecessary
}


[CreateAssetMenu(
    fileName = "New Item",
    menuName = "Game/Item Data")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public float price;
    public ItemType itemType;
    public GameObject prefab;

    public Sprite icon;  
}
