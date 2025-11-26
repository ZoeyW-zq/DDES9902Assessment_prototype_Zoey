using UnityEngine;

public class ProgressReporter : MonoBehaviour
{
    public bool countOnlyOnce = true;  // 大多数情况保持 true

    private bool hasReported = false;

    // 在 UnityEvent 里调用这个函数
    public void MarkCompleted()
    {
        if (countOnlyOnce && hasReported)
            return;

        hasReported = true;

        if (ProgressManager.Instance != null)
            ProgressManager.Instance.ReportBlockCompleted();
    }

    // 如果你有专门的 reset 而不重载场景，可以调用这个
    public void ResetReported()
    {
        hasReported = false;
    }
}
