using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OnButtonClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
