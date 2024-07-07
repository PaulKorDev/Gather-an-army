public class CallbackWithPriority
{
    // The higher the priority, the earlier the listener will be notified
    public readonly int Priority;
    public readonly object Callback;

    public CallbackWithPriority(int priority, object callback)
    {
        Priority = priority;
        Callback = callback;
    }
}