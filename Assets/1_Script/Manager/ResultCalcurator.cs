using UnityEngine;

public static class ResultCalculator
{
    public static ResultData Calculate()
    {
        ResultData result = new ResultData();

        var shoppingList =
            ShoppingListManager.Instance.currentShoppingList;

        var cartItems =
            CartManager.Instance.Items;

        foreach (var shopping in shoppingList)
        {
            int cartAmount = 0;

            cartItems.TryGetValue(
                shopping.itemData,
                out cartAmount);

            int correctAmount =
                Mathf.Min(cartAmount, shopping.amount);

            result.correctCount += correctAmount;

            if (correctAmount > 0)
            {
                result.correctItems.Add(
                    $"{shopping.itemData.itemName} " +
                    $"{correctAmount}/{shopping.amount}");
            }

            if (cartAmount < shopping.amount)
            {
                int missingAmount =
                    shopping.amount - cartAmount;

                result.missingCount += missingAmount;

                result.missingItems.Add(
                    $"{shopping.itemData.itemName} " +
                    $"Missing {missingAmount}");
            }

            if (cartAmount > shopping.amount)
            {
                int excessAmount =
                    cartAmount - shopping.amount;

                result.wrongCount += excessAmount;

                result.wrongItems.Add(
                    $"{shopping.itemData.itemName} " +
                    $"Extra ×{excessAmount}");
            }
        }

        foreach (var cart in cartItems)
        {
            bool isShoppingItem =
                ShoppingListManager.Instance
                    .IsShoppingItem(cart.Key);

            if (!isShoppingItem)
            {
                result.wrongCount += cart.Value;

                result.wrongItems.Add(
                    $"{cart.Key.itemName} ×{cart.Value}");
            }
        }

        result.totalPrice =
            CartManager.Instance.TotalPrice();

        result.score =
            result.correctCount * 100
            - result.wrongCount * 50
            - result.missingCount * 5;

        return result;
    }

    public static int CalculateCurrentScore()
    {
        ResultData result = Calculate();

        return result.correctCount * 100
            - result.wrongCount * 50;
    }

    public static int CalculateScore()
    {
        return Calculate().score;
    }
}