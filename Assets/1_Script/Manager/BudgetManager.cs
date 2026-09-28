using UnityEngine;

public class BudgetManager : MonoBehaviour
{
    public static BudgetManager Instance;

    public float Budget { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetBudget(float budget)
    {
        Budget = budget;
    }
}
