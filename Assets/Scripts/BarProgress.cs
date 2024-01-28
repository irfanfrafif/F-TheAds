using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarProgress : MonoBehaviour {
    public SpriteRenderer barRenderer;
    public GameObject winUI;

    public Vector2 startSize;
    public float currentProgress = 0;
    public float maxProgress = 100;
    private bool isFinished = false;

    [SerializeField] PopUpManager popUpManager;

    public UnityEvent onComplete;

    private void Start() {
        Time.timeScale = 1f;
        startSize = barRenderer.size;
        winUI.SetActive(false);
    }

    private void Update() {
        if (currentProgress <= maxProgress) {
            UpdateBar(currentProgress, maxProgress);
            currentProgress += Time.deltaTime;
        } else {
            FinishProgress();
        }
    }

    public void UpdateBar(float currentValues, float maxValues) {
        currentValues = Mathf.Clamp(currentValues, 0, maxValues);
        float barSize = (startSize.x / (float)maxValues) * (float)currentValues;
        barRenderer.size = new Vector2(barSize, startSize.y);
    }

    public void FinishProgress() {
        if (!isFinished && !GameManager.Instance.isOver) {
            Debug.Log("Finish");
            UpdateBar(maxProgress, maxProgress);
            //winUI.SetActive(true);
            isFinished = true;
            //Time.timeScale = 0f;
            AudioManager.instance.PlayAudio(7);
            popUpManager.CloseAllAd();
            popUpManager.isGameRunning = false;

            onComplete.Invoke();
        }
    }
}
