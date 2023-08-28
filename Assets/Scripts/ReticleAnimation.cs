using UnityEngine;

public class ReticleAnimation : MonoBehaviour
{
    private const float _scaleSpeed = 1;
    private const float _rotationSpeed = 40;
    private readonly Vector3 _scaleMultiplyer = Vector3.one;
    private bool _isGrowing;
    private float _originalScale;

    public void Start() => _originalScale = transform.localScale.x;

    // Update is called once per frame
    void Update()
    {
        UpdateScale();
        transform.localEulerAngles = new Vector3(0, Time.timeSinceLevelLoad * _rotationSpeed, 0);
        //float delta = _rotationSpeed * Time.deltaTime;
        //Quaternion rotation = Quaternion.AngleAxis(delta, Vector3.up);
        //transform.rotation = rotation * transform.rotation;
    }

    private void UpdateScale()
    {
        if (_isGrowing)
        {
            transform.localScale += GetScaleDelta();
            if (transform.localScale.x >= _originalScale)
            {
                _isGrowing = false;
            }
        }
        else
        {
            transform.localScale -= GetScaleDelta();
            if (transform.localScale.x < 0.35f)
            {
                _isGrowing = true;
            }
        }
    }

    private Vector3 GetScaleDelta() => Time.deltaTime * _scaleSpeed * _scaleMultiplyer;
}
