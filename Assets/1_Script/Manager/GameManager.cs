using UnityEngine;

public enum GameState
{
    Intro,
    Gameplay,
    Result
}

public class GameManager : MonoBehaviour
{
    /*private GameState gameState = GameState.Intro;*/

    public static GameManager Instance;

    private GameState currentState;
    [SerializeField] private ResultUI resultUI;


    private void Awake()
    {
        Instance = this;
    }


    public void GotoNextState(GameState nextState)
    {
        currentState = nextState;

        switch(currentState)
        {
            case GameState.Gameplay:
                break;
        }
    }
    
    public void ShowResult(ResultData result)
    {
        currentState = GameState.Result;

        resultUI.Show(result);
    }
    public GameState CurrentState => currentState;

}
