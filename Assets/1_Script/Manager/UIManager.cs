using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject instructionPanel;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private GameObject introListPanel;
    [SerializeField] private GameObject commonUI;

    [SerializeField] private TextMeshProUGUI welcomeBudgetText;
    [SerializeField] private TextMeshProUGUI welcomeTimeText;


    private void Start()
    {
        startPanel.SetActive(false);
        welcomePanel.SetActive(false);
        introListPanel.SetActive(false);
        commonUI.SetActive(false);
        instructionPanel.SetActive(false);
        creditPanel.SetActive(false);



    }

    public void ShowStart()
    {
        startPanel.SetActive(true);
        instructionPanel.SetActive(false);
        creditPanel.SetActive(false);
        AudioManager.Instance.PlayPanel();

    }

    public void ShowInstruction()
    {
        startPanel.SetActive(false);
        instructionPanel.SetActive(true);
        AudioManager.Instance.PlayPanel();

    }

    public void ShowCredit()
    {
        startPanel.SetActive(false);
        creditPanel.SetActive(true);
        AudioManager.Instance.PlayPanel();

    }

    public void BackToStart()
    {
        ShowStart();
        AudioManager.Instance.PlayButton();

    }

    public void ShowWelcome()
    {
        startPanel.SetActive(false);
        welcomePanel.SetActive(true);

        AudioManager.Instance.PlayPanel();


        welcomeBudgetText.text =
            $"${BudgetManager.Instance.Budget:0.00}";

        welcomeTimeText.text =
            TimerManager.Instance.TimeLimitString;
    }

    public void ShowIntroList()
    {
        welcomePanel.SetActive(false);
        introListPanel.SetActive(true);
        AudioManager.Instance.PlayPanel();

    }

    public void ShowCommonUI()
    {
        introListPanel.SetActive(false);
        commonUI.SetActive(true);
        AudioManager.Instance.PlayPanel();

    }


}
