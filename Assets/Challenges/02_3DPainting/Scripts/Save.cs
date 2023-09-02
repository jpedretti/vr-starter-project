using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    [SerializeField] private GameObject[] _savePoints;
    [SerializeField] private Button _saveButton;
    [SerializeField] private GameObject _shapeSpawn;

    private int _savePointIndex = 0;

    public void SaveTrail()
    {
        if (_saveButton.interactable)
        {
            SaveTrails();
            SaveShape();

            _savePointIndex++;
        }

        _saveButton.interactable = _savePointIndex < _savePoints.Length;
    }

    private void SaveShape()
    {
        if (_shapeSpawn.transform.childCount > 0)
        {
            var copy = Instantiate(_shapeSpawn.transform.GetChild(0));
            copy.transform.SetParent(_savePoints[_savePointIndex].transform, false);
            Destroy(_shapeSpawn.transform.GetChild(0).gameObject);
        }
    }

    private void SaveTrails()
    {
        foreach (var trail in GetComponentsInChildren<MeshFilter>())
        {
            trail.tag = "SavedTrail";
            trail.transform.SetParent(_savePoints[_savePointIndex].transform, false);
        }
    }
}
