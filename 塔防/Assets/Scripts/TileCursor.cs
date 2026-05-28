using UnityEngine;

public class TileCursor : MonoBehaviour
{
[field: SerializeField]
public GameObject TargetGrid { get; private set; }

void OnEnable()
{
    ListenToTilesIn(TargetGrid);
}

void OnDisable()
{
    StopListeningToTilesIn(TargetGrid);
}

public void ListenToTilesIn(GameObject grid)
{
    foreach (TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
    {
        tile.OnCursorEnter.AddListener(HandleTileEntered);
    }
}

    public void HandleTileEntered(TileBehavior tile)
    {
        transform.position = tile.transform.position;
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach(TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
        {
            tile.OnCursorEnter.RemoveListener(HandleTileEntered);
        }
    }
}
