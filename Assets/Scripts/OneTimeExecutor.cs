using UnityEngine;
using UnityEngine.Events;

public class OneTimeExecutor : MonoBehaviour
{
    [SerializeField] private UnityEvent _executeOnce;

    private bool hasExecuted = false;

    public void ExceuteOnce()
    {
        if (!hasExecuted)
        {
            hasExecuted = true;
            _executeOnce.Invoke();
        }
    }
}
