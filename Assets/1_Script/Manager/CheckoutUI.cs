using TMPro;
using UnityEngine;

public class CheckoutUI : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [SerializeField] private TextMeshProUGUI cartItemText;
    [SerializeField] private TextMeshProUGUI budgetText;
    [SerializeField] private TextMeshProUGUI totalText;
    [SerializeField] private GameObject backButton;

    public void Show(bool canGoBack = true)
    {
        panel.SetActive(true);

        UpdateCartList();

        budgetText.text =
            $"RM {BudgetManager.Instance.Budget:0.00}";

        totalText.text =
            $"RM {CartManager.Instance.TotalPrice():0.00}";
        
        backButton.SetActive(canGoBack);

        AudioManager.Instance.PlayPanel();


    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    private void UpdateCartList()
    {
        cartItemText.text = "";

        foreach (var item in CartManager.Instance.Items)
        {
            string itemName = item.Key.itemName;
            int amount = item.Value;
            float subtotal = item.Key.price * amount;

            cartItemText.text +=
                $"{itemName}  x{amount}    RM {subtotal:0.00}\n";
        }

        if (CartManager.Instance.Items.Count == 0)
        {
            cartItemText.text = "Your cart is empty.";
        }
    }

    public void OnBackButton()
    {
        Hide();

        TimerManager.Instance.ResumeTimer();

        ShoppingManager.Instance.ChangeState(
            ShoppingState.Shopping);

        AudioManager.Instance.PlayButton();

    }

    public void OnPayButton()
    {
        Hide();

        ShoppingManager.Instance.ChangeState(
            ShoppingState.Finished);
            
        AudioManager.Instance.PlayButton();

    }
}