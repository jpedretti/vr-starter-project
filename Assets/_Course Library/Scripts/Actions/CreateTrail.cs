using UnityEngine;

/// <summary>
/// This script creates a trail at the location of a gameobject with a particular width and color.
/// </summary>

public class CreateTrail : MonoBehaviour
{
    [SerializeField] private GameObject trailPrefab = null;
    [SerializeField] private GameObject parentToFinishedTrails;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _trailMeshPreFab;

    private float width = 0.05f;
    private Color color = Color.white;

    private GameObject currentTrail = null;

    public void StartTrail()
    {
        if (!currentTrail)
        {
            currentTrail = Instantiate(trailPrefab, transform.position, transform.rotation, transform);
            ApplySettings(currentTrail);
        }
    }

    private void ApplySettings(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = width;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }

    public void EndTrail()
    {
        if (currentTrail)
        {
            Mesh mesh = CreateMeshFromTrail();
            CreateTrailCopyWithMesh(mesh);

            Destroy(currentTrail);
            currentTrail = null;
        }
    }

    private void CreateTrailCopyWithMesh(Mesh mesh)
    {
        Instantiate(_trailMeshPreFab).Apply(trailMesh =>
        {
            trailMesh.GetComponent<MeshFilter>().mesh = mesh;
            trailMesh.transform.SetParent(parentToFinishedTrails.transform, true);
            trailMesh.tag = "Trail";
        });
    }

    private Mesh CreateMeshFromTrail()
    {
        Mesh mesh = new();
        currentTrail.GetComponent<TrailRenderer>().Apply(rend =>
        {
            rend.emitting = false;
            rend.BakeMesh(mesh, _camera);

        });
        return mesh;
    }

    public void SetWidth(float value)
    {
        width = value;
    }

    public void SetColor(Color value)
    {
        color = value;
    }
}
