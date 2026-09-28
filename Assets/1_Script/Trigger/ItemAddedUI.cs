using TMPro;
using UnityEngine;
using System.Collections;

public class ItemAddedUI : MonoBehaviour
{
    public static ItemAddedUI Instance;

    [SerializeField]
    private GameObject panel;

    private Coroutine routine;

    private void Awake()
    {
        Instance = this;
    }

    public void Show()
    {
        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine()
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(1f);

        panel.SetActive(false);
    }
}