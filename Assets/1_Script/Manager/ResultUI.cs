using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI correctItemText;
    [SerializeField] private TextMeshProUGUI wrongItemText;
    [SerializeField] private TextMeshProUGUI missingItemText;


    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI budgetLeftText;
    [SerializeField] private TextMeshProUGUI mistakeText;
    [SerializeField] private TextMeshProUGUI ratingText;


    [SerializeField] private GameObject panel;


    public void Show(ResultData result)
    {
        panel.SetActive(true);

        AudioManager.Instance.PlayResult();


        int mistakeCount =
            result.wrongItems.Count +
            result.missingItems.Count;

        float budgetLeft =
            BudgetManager.Instance.Budget -
            result.totalPrice;

        scoreText.text =
            result.score.ToString();

        budgetLeftText.text =
            $"RM {budgetLeft:0.00}";

        mistakeText.text =
            mistakeCount.ToString();

        ratingText.text =
            GetRating(mistakeCount, budgetLeft);
    }

    private string GetRating(
        int mistakeCount,
        float budgetLeft)
    {
        bool withinBudget = budgetLeft >= 0f;

        if (mistakeCount == 0 && withinBudget)
        {
            return "EXCELLENT SHOPPER";
        }

        if (mistakeCount <= 2 && withinBudget)
        {
            return "GOOD SHOPPER";
        }

        return "KEEP TRYING";
    }

    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        FadeManager.Instance.Restart();

            AudioManager.Instance.PlayButton();

    }
}
