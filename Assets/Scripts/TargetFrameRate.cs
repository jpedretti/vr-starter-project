using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{

    [SerializeField] private int _targetFrameRate = 90;

    public void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
        QualitySettings.vSyncCount = 0;
    }
}
