using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeControl : MonoBehaviour
{
    public AudioSource bgmSource;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        volumeSlider.value = bgmSource.volume;
    }

    void OnVolumeChanged(float value)
    {
        bgmSource.volume = value;
    }
}

