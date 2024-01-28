using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera cam;

    public bool isOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOver) {
            isOver = false;
            SceneManager.LoadScene("Main");
        }
    }

    public void SetGameOver(bool b)
    {
        isOver = b;
    }
}
