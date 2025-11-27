using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderCompleteEvent : MonoBehaviour
{
    public Slider slider;
    public UnityEvent onSliderFull;

    private bool hasTriggered = false;

    void Start()
    {
        if (slider == null) slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        if (!hasTriggered && value >= 1.0f)
        {
            hasTriggered = true;
            onSliderFull.Invoke();
        }
    }
}
