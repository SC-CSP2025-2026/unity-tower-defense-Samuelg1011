using UnityEngine;
using UnityEngine.Events;

public class TileBehavior : MonoBehaviour
{

    [field: SerializeField]
    public bool IsOccupied { get; private set; } = false;

    [field: SerializeField]
    public UnityEvent<TileBehavior> OnCursorEnter;

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }
}
