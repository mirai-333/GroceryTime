using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class CartUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI needText;
    [SerializeField] private TextMeshProUGUI unnecessaryText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI budgetText;


    private void Start()
    {
        CartManager.Instance.OnCartChanged += UpdateUI;

        UpdateUI();
    }

    private void OnDestroy()
    {
        if (CartManager.Instance != null)
            CartManager.Instance.OnCartChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        float totalPrice =
            CartManager.Instance.TotalPrice();

        float budgetLeft =
            BudgetManager.Instance.Budget - totalPrice;

        priceText.text =
            $"RM {totalPrice:0.00}";

        needText.text =
            CartManager.Instance.NeedItemCount().ToString();

        unnecessaryText.text =
            CartManager.Instance.UnnecessaryItemCount().ToString();

        scoreText.text =
            CartManager.Instance.CurrentScore().ToString();

        if (budgetLeft >= 0)
        {
            budgetText.text =
                $"RM {budgetLeft:0.00}";
        }
        else
        {
            budgetText.text =
                $"EXCEEDED";
        }
    }
}