using System;
using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject _hourHand;
    [SerializeField] private GameObject _minuteHand;
    [SerializeField] private GameObject _secondHand;

    void Start() => StartCoroutine(UpdateClock());

    private IEnumerator UpdateClock()
    {
        const int degreesPerMinOrSec = 6;
        const int degreesPerHour = 30;

        while (true)
        {
            SetHour(degreesPerHour);
            SetMinutes(degreesPerMinOrSec);
            UpdateSeconds(degreesPerMinOrSec);
            yield return new WaitForSeconds(1);
        }
    }

    private void SetHour(float degreesPerHour)
    {
        var hour = (DateTime.Now.Hour % 12) + (DateTime.Now.Minute / 60f);
        var angle = GetAngle(degreesPerHour, hour);
        _hourHand.transform.localEulerAngles = GetForXAngle(xAngle: angle);
    }

    private void SetMinutes(float degreesPerMinOrSec)
    {
        var minutes = DateTime.Now.Minute;
        var angle = GetAngle(minutes, degreesPerMinOrSec);
        _minuteHand.transform.localEulerAngles = GetForXAngle(xAngle: angle);
    }

    private void UpdateSeconds(float degreesPerMinOrSec)
    {
        var seconds = DateTime.Now.Second;
        var angle = GetAngle(seconds, degreesPerMinOrSec);
        _secondHand.transform.localEulerAngles = GetForXAngle(xAngle: angle);
    }

    private static float GetAngle(float degreesPerHour, float hour) => hour * degreesPerHour;
    private static Vector3 GetForXAngle(float xAngle) => new(xAngle, 0, 0);
}
