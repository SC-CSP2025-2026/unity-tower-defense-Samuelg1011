using UnityEngine;
using UnityEngine.Events;

public class TileBehavior : MonoBehaviour
{

    [field: SerializeField]
    public bool IsOccupied { get; private set; } = false;

    [field: SerializeField]
    public UnityEvent<TileBehavior> OnCursorEnter;

    [field: SerializeField]
    public UnityEvent<TileBehavior> OnCursorExit;

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }

    public void NotifyCursorExit()
    {
        OnCursorExit.Invoke(this);
    }
}
