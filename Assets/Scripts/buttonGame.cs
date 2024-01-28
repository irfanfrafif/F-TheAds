using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonGame : MonoBehaviour
{
    public void clickReplay() {
        SceneManager.LoadScene("Main");
    }
    public void clickShutDown() {
        Application.Quit();
    }
}
