using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonLoadScenes: MonoBehaviour
{

    public string nameScene = "Portada";

    public void OnMouseDown()
    {
        SceneManager.LoadScene(nameScene);
        //Application.LoadLevel("MainScene");
    }
}