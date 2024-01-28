using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonMainMenu : MonoBehaviour
{
    public void clickPlay() {
        SceneManager.LoadScene("Main");
    }
    public void clickShutDown() {
        Application.Quit();
    }
}
