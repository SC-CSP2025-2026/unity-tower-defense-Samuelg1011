using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [field: SerializeField]
    public EnemyMovement Enemy { get; private set; }

    [field: SerializeField]
    public Waypoint StartingWaypoint { get; private set; }

    [field: SerializeField]
    public float Delay {get; private set; } = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Spawn), Delay, Delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        EnemyMovement newEnemy = Object.Instantiate(Enemy);
        newEnemy.Target = StartingWaypoint;
    }
}
