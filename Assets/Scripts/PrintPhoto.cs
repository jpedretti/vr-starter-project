using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrintPhoto : MonoBehaviour
{
    private bool _isPrinted = false;
    private bool _isPrinting = false;
    private float _photoSpeed;
    private float _printTime;

    private const float _totalToMove = 0.12f;

    public void Update()
    {
        if (_isPrinted)
        {
            enabled = false;
        }
        else if (_isPrinting)
        {
            transform.Translate(new(0, 0, _photoSpeed * Time.deltaTime), Space.Self);
        }
    }

    public void Print(float printTime)
    {
        _printTime = printTime;
        _photoSpeed = _totalToMove / _printTime;
        StartCoroutine(PrintPhotoTimer(GetComponent<XRGrabInteractable>()));
    }

    private IEnumerator PrintPhotoTimer(XRGrabInteractable grabInteractable)
    {
        _isPrinting = true;
        yield return new WaitForSeconds(_printTime);
        grabInteractable.enabled = true;
        _isPrinted = true;
        _isPrinting = false;
    }
}
