using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        timerText.text =
            TimerManager.Instance.CurrentTimeString;
    }
}