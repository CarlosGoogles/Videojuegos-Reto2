using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void ButtonChangeScene(string sScene)
    {
        if (sScene == "Salir")
        {
            Application.Quit();
        }
        SceneManager.LoadScene(sScene);
    }
}

