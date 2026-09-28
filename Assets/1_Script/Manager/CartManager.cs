using UnityEngine;
using System;
using System.Collections.Generic;

public class CartManager : MonoBehaviour
{
    public static CartManager Instance;

    public event Action OnCartChanged;

    private Dictionary<ItemData, int> items = new();

    public IReadOnlyDictionary<ItemData, int> Items => items;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        if (items.ContainsKey(item))
            items[item]++;
        else
            items.Add(item, 1);

        OnCartChanged?.Invoke();
        
    }

    public float TotalPrice()
    {
        float total = 0f;

        foreach (var item in items)
        {
            total += item.Key.price * item.Value;
        }

        return total;
    }

    public int CurrentScore()
    {
        return ResultCalculator.CalculateCurrentScore();

    }

    public int NeedItemCount()
    {
        int count = 0;

        foreach (var item in items)
        {
            if (item.Key.itemType == ItemType.Need)
                count += item.Value;
        }

        return count;
    }

    public int UnnecessaryItemCount()
    {
        int count = 0;

        foreach (var item in items)
        {
            if (item.Key.itemType == ItemType.Unnecessary)
                count += item.Value;
        }

        return count;
    }

    
}