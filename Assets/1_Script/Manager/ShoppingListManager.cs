using UnityEngine;
using System.Collections.Generic;

public class ShoppingItem
{
    public ItemData itemData;
    public int amount;
}

public class ShoppingListManager : MonoBehaviour
{
    public static ShoppingListManager Instance;

    private int shoppingItemCount = 5;

    [SerializeField] private List<ItemData> needItems;
    public List<ShoppingItem> currentShoppingList = new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GenerateShoppingList(shoppingItemCount);
    }

    public void GenerateShoppingList(int count)
    {
        currentShoppingList.Clear();

        List<ItemData> temp = new List<ItemData>(needItems);

        while (currentShoppingList.Count < count && temp.Count > 0)
        {
            int index = Random.Range(0, temp.Count);

            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.itemData = temp[index];
            shoppingItem.amount = Random.Range(1, 3);

            currentShoppingList.Add(shoppingItem);

            temp.RemoveAt(index);
        }

        float total = 0f;

        foreach (var shoppingItem in currentShoppingList)
        {
            total += shoppingItem.itemData.price * shoppingItem.amount;
        }

        /*float extraBudget = Random.Range(10f, 26f);*/

        BudgetManager.Instance.SetBudget(total);

    }

    public bool IsShoppingItem(ItemData item)
    {
        foreach (var shoppingItem in currentShoppingList)
        {
            if (shoppingItem.itemData == item)
                return true;
        }

        return false;    
    }
}
