using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ShoppingListUI : MonoBehaviour
{
    [Header("Item Name")]
    [SerializeField] private TextMeshProUGUI[] itemTexts;

    [Header("Amount")]
    [SerializeField] private TextMeshProUGUI[] amountTexts;

    [SerializeField] private Image[] itemImages;

    [SerializeField] private GameObject listPanel;


    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < itemTexts.Length; i++)
        {
            itemTexts[i].text = "";
            amountTexts[i].text = "";


            itemImages[i].sprite = null;
            itemImages[i].gameObject.SetActive(false);
        }

        for (int i = 0;
             i < ShoppingListManager.Instance.currentShoppingList.Count;
             i++)
        {
            ShoppingItem item =
                ShoppingListManager.Instance.currentShoppingList[i];

            itemTexts[i].text =
                item.itemData.itemName;

            amountTexts[i].text =
                $"×{item.amount}";

            itemImages[i].sprite =
                item.itemData.icon;

            itemImages[i].preserveAspect = true;
            itemImages[i].gameObject.SetActive(true);
        }
    }

    public void ClickedList()
    {
        listPanel.SetActive(!listPanel.activeSelf);
        AudioManager.Instance.PlayButton();


    }


}
