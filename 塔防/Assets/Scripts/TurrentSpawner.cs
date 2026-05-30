using UnityEngine;

public class TurrentSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public GameObject TurretPrefab { get; private set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

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
            tile.OnCursorClicked.AddListener(SpawnTurret);
        }
    }

    public void SpawnTurret(TileBehavior tileBehavior)
    {
        if (tileBehavior.IsOccupied)
        {
            return;
        }
        GameObject newTurret = Instantiate(TurretPrefab);
        newTurret.transform.position = tileBehavior.transform.position;
        tileBehavior.IsOccupied = true;
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
        {
            tile.OnCursorClicked.RemoveListener(SpawnTurret);
        }
    }
}
