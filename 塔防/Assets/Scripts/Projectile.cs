using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 2f;

    [field: SerializeField]
    public float Damage { get; private set; } = 1f;

    [field: SerializeField]
    public Transform Target { get; private set; }
}
