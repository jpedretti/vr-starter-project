using UnityEngine;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class LaunchProjectile : MonoBehaviour
{
    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 1.0f;

    [Tooltip("The colliders to ignore physics with the projectile")]
    [SerializeField] private Collider[] _coliders;

    public void Fire()
    {
        GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);
        IgnoreColliders(newObject);

        if (newObject.TryGetComponent(out Rigidbody rigidBody))
        {
            ApplyForce(rigidBody);
        }
        else
        {
            Debug.LogError($"No Rigidibody set on {projectilePrefab.name}");
        }
    }

    private void IgnoreColliders(GameObject newObject)
    {
        if (newObject.TryGetComponent(out Collider otherCollider))
        {
            foreach (var collider in _coliders)
            {
                Physics.IgnoreCollision(otherCollider, collider);
            }
        }
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = startPoint.forward * launchSpeed;
        rigidBody.AddForce(force);
    }
}
