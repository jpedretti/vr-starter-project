using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperienceSelector : MonoBehaviour
{

    public void OnExpereinceSelected(int scene)
    {
        if (scene > 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
