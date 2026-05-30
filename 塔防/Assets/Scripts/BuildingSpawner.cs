using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{

    [field: SerializeField]
    public BuildingData Selected { get; set; }
     
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public GameObject TurretPrefab { get; set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
        Controller.InfoLabel.text = "Select a Tile";
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        Controller.InfoLabel.text = "Click Build to Place a Turret";
        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {

        foreach (TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
        {
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(HandleTileExited);
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
            GameObject newTurret = Instantiate(Selected.BuildingPrefab, Controller.transform);
            newTurret.transform.position = tileBehavior.transform.position;
            tileBehavior.IsOccupied = true;
            Controller.Gold -= Selected.Cost;
            gameObject.SetActive(false);
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileBehavior tile in grid.GetComponentsInChildren<TileBehavior>())
        {
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(HandleTileExited);
            tile.OnCursorClicked.RemoveListener(SpawnTurret);
        }
    }

    public bool CanSpawn(TileBehavior tileBehavior)
    {
        if(tileBehavior.IsOccupied)
        {
            return false;
        }

        if (Controller.Gold < Selected.Cost)
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
        else if (Controller.Gold < Selected.Cost)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough</color>";
        }
        else 
        {
            if(Selected.Cost == 50)
           {
             Controller.InfoLabel.text = "50 Gold - Place Turret";
           }
           else if(Selected.Cost == 80)
           {
             Controller.InfoLabel.text = "80 Gold - Place Turret";
           }
           else if(Selected.Cost == 30)
           {
             Controller.InfoLabel.text = "30 Gold - Place Turret";
           }
            else if(Selected.Cost == 150)
           {
             Controller.InfoLabel.text = "150 Gold - Place Turret";
           }
            else if(Selected.Cost == 60)
           {
             Controller.InfoLabel.text = "60 Gold - Place Turret";
           }
        }
    }

    public void HandleTileExited(TileBehavior tileBehavior)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }
}
