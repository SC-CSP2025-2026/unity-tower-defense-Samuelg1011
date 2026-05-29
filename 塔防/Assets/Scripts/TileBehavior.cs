using UnityEngine;
using UnityEngine.Events;

public class TileBehavior : MonoBehaviour
{

    [field: SerializeField]
    public bool IsOccupied { get; set; } = false;

    [field: SerializeField]
    public UnityEvent<TileBehavior> OnCursorEnter;

    [field: SerializeField]
    public UnityEvent<TileBehavior> OnCursorExit;

    [field: SerializeField]
    public UnityEvent<TileBehavior> OnCursorClicked;

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }

    public void NotifyCursorExit()
    {
        OnCursorExit.Invoke(this);
    }

    public void NotifyCursorClicked()
    {
        OnCursorClicked.Invoke(this);
    }
}
