using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    [SerializeField] private float timeLimit = 600f;

    private float currentTime;
    private bool isRunning;
    private bool isTimeUp;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!isRunning)
            return;

        currentTime -= Time.deltaTime;

        if (!isTimeUp && currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            isTimeUp = true;

            ShoppingManager.Instance.ChangeState(ShoppingState.TimeUp);
        }
    }

    public void StartTimer()
    {
        currentTime = timeLimit;
        isRunning = true;
        isTimeUp = false;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    public float CurrentTime => currentTime;

    public float TimeLimit => timeLimit;

    public string CurrentTimeString =>
        $"{Mathf.FloorToInt(currentTime / 60):00}:{Mathf.FloorToInt(currentTime % 60):00}";

    public string TimeLimitString =>
        $"{Mathf.FloorToInt(timeLimit / 60):00}:{Mathf.FloorToInt(timeLimit % 60):00}";
}