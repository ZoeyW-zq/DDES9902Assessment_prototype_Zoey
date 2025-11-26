using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    [Header("UI")]
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
        // 自动统计：场景里有多少个需要计数的方块
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
        if (progressText != null)
            progressText.text = $"{completedCount} / {totalBlocks}";
    }
}
