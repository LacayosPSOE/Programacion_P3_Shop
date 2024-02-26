using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OnButtonClick(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
}
