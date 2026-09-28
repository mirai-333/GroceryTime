using UnityEngine;
using System.Collections;


public enum ShoppingState
{
    Waiting,   
    Shopping,   
    TimeUp,
    Checkout,  
    Finished   
}

public class ShoppingManager : MonoBehaviour
{

    public static ShoppingManager Instance;
    
    [SerializeField] private CheckoutUI checkoutUI;
    [SerializeField] private GameObject timeUpUI;
    [SerializeField] private GameObject timeUpCanvas;
    [SerializeField] private Transform player;
    [SerializeField] private Transform checkoutPoint;

    private ShoppingState currentState;
    private bool isTimeUpCheckout;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeState(ShoppingState nextState)
    {
        currentState = nextState;

        switch (currentState)
        {
            case ShoppingState.Waiting:
                break;

            case ShoppingState.Shopping:
                isTimeUpCheckout = false;
                /*TimerManager.Instance.StartTimer();*/
                break;

            case ShoppingState.TimeUp:
                isTimeUpCheckout = true;
                StartCoroutine(TimeUpRoutine());
                break;

            case ShoppingState.Checkout:
                TimerManager.Instance.StopTimer();
                checkoutUI.Show(!isTimeUpCheckout);
                break;

            case ShoppingState.Finished:
                ResultData result =
                    ResultCalculator.Calculate();

                GameManager.Instance.ShowResult(result);

                /*resultUI.Show(result);

                GameManager.Instance.GotoNextState(GameState.Result);*/

                break;
        }
    }

    public ShoppingState CurrentState => currentState;

    public void Finish()
    {
        ChangeState(ShoppingState.Finished);

    }

    private IEnumerator TimeUpRoutine()
    {
        timeUpCanvas.SetActive(true);
        timeUpUI.SetActive(true);

        AudioManager.Instance.PlayTimeUp();


        yield return new WaitForSeconds(2f);

        player.position = checkoutPoint.position;
        player.rotation = checkoutPoint.rotation;

        timeUpUI.SetActive(false);  
        timeUpCanvas.SetActive(false);


        ChangeState(ShoppingState.Checkout);
    }
}




/*
    private void Awake()
    {
        Instance = this;
    }

    public GameObject SpawnItem(ItemData itemData, Transform spawnPoint)
    {
        return Instantiate(
            itemData.prefab,
            spawnPoint.position,
            spawnPoint.rotation);
    }
    [SerializeField] private Transform spawnPoint;


    public void SpawnItem(ItemData itemData)
    {
        GameObject obj = Instantiate(
            itemData.prefab,
            spawnPoint.position,
            spawnPoint.rotation);

    }*/