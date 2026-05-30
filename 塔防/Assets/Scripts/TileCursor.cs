using UnityEngine;

public class TileCursor : MonoBehaviour
{
[field: SerializeField]
public GameObject TargetGrid { get; private set; }

[field: SerializeField]
public GameObject Model { get; private set; }

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
        tile.OnCursorExit.AddListener(HandleTileExited);
    }
}

    public void HandleTileEntered(TileBehavior tile)
    {
        transform.position = tile.transform.position;
        Model.SetActive(true);
    }

    public void HandleTileExited(TileBehavior tile)
    {
        Model.SetActive(false);
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null )
        {
            return;
        }
        foreach(TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
        {
             
            tile.OnCursorEnter.RemoveListener(HandleTileEntered);
            tile.OnCursorExit.RemoveListener(HandleTileExited);
        }
    }
}
