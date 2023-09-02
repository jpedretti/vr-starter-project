using System;
using UnityEngine;

public class RotateByDegrees : MonoBehaviour
{
    public void RotateYBy(float angleY) => transform.rotation = Quaternion.Euler(0, angleY, 0);
}

public static class ObjectExtensions
{
    public static T Apply<T>(this T obj, Action<T> func)
    {
        func.Invoke(obj);
        return obj;
    }
}