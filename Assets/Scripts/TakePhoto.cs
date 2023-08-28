using UnityEngine;

public class TakePhoto : MonoBehaviour
{
    [SerializeField] GameObject _photoPreFab;
    [SerializeField] GameObject _photoParent;
    [SerializeField] Camera _camera;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    public void Take()
    {
        Texture2D image = ReadPixels();
        GameObject photo = CreatePhoto(image);
        IgnoreColliders(photo);
        PlaySound();
        photo.GetComponent<PrintPhoto>().Print(_audioClip.length);
    }

    private void PlaySound()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }

    private void IgnoreColliders(GameObject photo)
    {
        var photoCollider = photo.GetComponentInChildren<Collider>();
        foreach (var collider in transform.parent.GetComponentsInChildren<Collider>())
        {
            Physics.IgnoreCollision(photoCollider, collider);
        }
    }

    private GameObject CreatePhoto(Texture2D image)
    {
        var photo = Instantiate(_photoPreFab, _photoParent.transform);
        foreach (var renderer in photo.GetComponentsInChildren<Renderer>())
        {
            if (renderer.gameObject.CompareTag("Film"))
            {
                renderer.material.mainTexture = image;
            }
        }

        return photo;
    }

    private Texture2D ReadPixels()
    {
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = _camera.targetTexture;

        // Render the camera's view.
        _camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new(_camera.targetTexture.width, _camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, _camera.targetTexture.width, _camera.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        return image;
    }
}
