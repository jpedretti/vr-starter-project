using UnityEngine;

public class RemoveParent : MonoBehaviour
{
    public void Remove()
    {
        transform.SetParent(null);
        enabled = false;
    }
}
