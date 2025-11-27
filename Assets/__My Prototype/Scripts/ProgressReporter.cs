using UnityEngine;

public class ProgressReporter : MonoBehaviour
{
    public bool countOnlyOnce = true;  // 大多数情况保持 true

    private bool hasReported = false;

    public void MarkCompleted()
    {
        if (countOnlyOnce && hasReported)
            return;

        hasReported = true;

        if (ProgressManager.Instance != null)
            ProgressManager.Instance.ReportBlockCompleted();
    }

    
    public void ResetReported()
    {
        hasReported = false;
    }
}
