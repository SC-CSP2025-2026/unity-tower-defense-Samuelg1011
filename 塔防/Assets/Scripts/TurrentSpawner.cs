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
        if (CanSpawn(tileBehavior))
        {
            GameObject newTurret = Instantiate(TurretPrefab);
            newTurret.transform.position = tileBehavior.transform.position;
            tileBehavior.IsOccupied = true;
            Controller.Gold -= 50;
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
        {
            tile.OnCursorClicked.RemoveListener(SpawnTurret);
        }
    }

    public bool CanSpawn(TileBehavior tileBehavior)
    {
        if(tileBehavior.IsOccupied)
        {
            return false;
        }

        if (Controller.Gold < 50)
        {
            return false;
        }

        return true;
    }

    public void ShowInfo(TileBehavior tileBehavior)
    {
        if (tileBehavior.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < 50)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough</color>";
        }
        else 
        {
            Controller.InfoLabel.text = "50 Gold - Place Turret";
        }
    }
}
