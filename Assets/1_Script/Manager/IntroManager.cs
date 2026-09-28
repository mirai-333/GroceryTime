using UnityEngine;


public enum IntroState
{
    None,
    Welcome,
    GroceryNote,
    Finished
}

public class IntroManager : MonoBehaviour
{
    // script
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;


    private IntroState currentState = IntroState.None;

    private void Start()
    {
        uiManager.ShowStart();
    }

    private void SetState(IntroState nextState)
    {
        currentState = nextState;

        switch (currentState)
        {
            case IntroState.Welcome:
                uiManager.ShowWelcome();
                break;

            case IntroState.GroceryNote:
                uiManager.ShowIntroList();
                break;

            case IntroState.Finished:
                uiManager.ShowCommonUI();

                GameManager.Instance.GotoNextState(GameState.Gameplay);

                ShoppingManager.Instance.ChangeState(
                    ShoppingState.Waiting);

                break;
        }

    }

    public void ClickedNext()
    {
        SetState(GetNextState());
        AudioManager.Instance.PlayButton();

    }

    private IntroState GetNextState()
    {
        switch(currentState)
        {
            case IntroState.None:
                return IntroState.Welcome;

            case IntroState.Welcome:
                return IntroState.GroceryNote;

            case IntroState.GroceryNote:
                return IntroState.Finished;

            default:
                return IntroState.Finished;
        }
    }
}
