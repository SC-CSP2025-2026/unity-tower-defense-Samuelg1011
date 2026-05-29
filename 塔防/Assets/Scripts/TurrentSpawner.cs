using UnityEngine;

public class TurrentSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurretPrefab { get; private set; }

    public void SpawnTurret(TileBehavior tileBehavior)
    {
        if (tileBehavior.IsOccupied)
        {
            return;
        }
        GameObject newTurret = Instantiate(TurretPrefab);
        newTurret.transform.position = tileBehavior.transform.position;
    }
}
