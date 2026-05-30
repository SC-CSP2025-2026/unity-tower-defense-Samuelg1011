using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [field: SerializeField]
    public AOE AoE { get; private set; }

    [field: SerializeField]
    public Projectile ProjectilePrefab { get; private set; }

    [field: SerializeField]
    public float CooldownTime { get; private set; } = 3f;

    [field: SerializeField]
    public bool IsCoolingDown { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        if(IsCoolingDown || AoE.Targets.Count == 0)
        {
            return;
        }

        Fire(); 
        IsCoolingDown = true;
        Invoke(nameof(SetIsCoolingDownToFalse), CooldownTime);
    }

    public void SetIsCoolingDownToFalse()
    {
        IsCoolingDown = false;
    }

    public void Fire() 
    {
        Projectile newProjectile = Instantiate(ProjectilePrefab);
        newProjectile.transform.position = transform.position;
        newProjectile.Target = AoE.Targets[0].transform;
    }
}
