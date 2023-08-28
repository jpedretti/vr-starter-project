using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class FireController : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    void Start() => _particleSystem = GetComponent<ParticleSystem>();

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire") && other.GetComponent<ParticleSystem>().isPlaying == true)
        {
            _particleSystem.Play();
        }
    }

    public void PutOutFire() => _particleSystem.Stop();
}
