using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        else if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Gameplay");
    }
}
