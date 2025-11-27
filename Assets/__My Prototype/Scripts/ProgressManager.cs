using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    public Slider progressSlider;
    public TextMeshProUGUI progressText;

    private int totalBlocks;
    private int completedCount;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        
        var reporters = FindObjectsOfType<ProgressReporter>();
        totalBlocks = reporters.Length;

        if (progressSlider != null)
        {
            progressSlider.minValue = 0;
            progressSlider.maxValue = totalBlocks;
            progressSlider.value = 0;
        }

        UpdateText();
    }

    public void ReportBlockCompleted()
    {
        completedCount++;
        if (completedCount > totalBlocks)
            completedCount = totalBlocks;

        if (progressSlider != null)
            progressSlider.value = completedCount;

        UpdateText();
    }

    private void UpdateText()
    {
        if (progressText == null)
        {
            return;
        }

        if (completedCount >= totalBlocks)
            progressText.text = "You're amazing!";
        else
            progressText.text = $"{completedCount} / {totalBlocks}";
    }

}
