using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1f;

    private void Awake()
    {
        Instance = this;
        fadeCanvas.SetActive(false);
    }

    public void Restart()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        fadeCanvas.SetActive(true);

        yield return StartCoroutine(Fade(0f, 1f));

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator Fade(float from, float to)
    {
        float t = 0f;

        Color color = fadeImage.color;
        color.a = from;
        fadeImage.color = color;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            color.a = Mathf.Lerp(from, to, t / fadeTime);
            fadeImage.color = color;

            yield return null;
        }

        color.a = to;
        fadeImage.color = color;
    }
}