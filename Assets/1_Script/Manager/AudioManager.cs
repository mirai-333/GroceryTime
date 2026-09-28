using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    [Header("SE")]
    [SerializeField] private AudioClip buttonSE;
    [SerializeField] private AudioClip panelSE;
    [SerializeField] private AudioClip addedSE;
    [SerializeField] private AudioClip timeUpSE;
    [SerializeField] private AudioClip resultSE;
    [SerializeField] private AudioClip fridgeOpen;
    [SerializeField] private AudioClip fridgeClose;


    [Header("BGM")]
    [SerializeField] private AudioClip shopBGM;

    private void Awake()
    {
        Instance = this;
        bgmSource.clip = shopBGM;

    }

    public void PlayButton()
        => seSource.PlayOneShot(buttonSE);

    public void PlayPanel()
        => seSource.PlayOneShot(panelSE);

    public void PlayAdded()
        => seSource.PlayOneShot(addedSE);

    public void PlayTimeUp()
        => seSource.PlayOneShot(timeUpSE);

    public void PlayResult()
        => seSource.PlayOneShot(resultSE);

    public void PlayFridgeOpen()
        => seSource.PlayOneShot(fridgeOpen);

    public void PlayFridgeClose()
        => seSource.PlayOneShot(fridgeClose);

    public void PlayBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}