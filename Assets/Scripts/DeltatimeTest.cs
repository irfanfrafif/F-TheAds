using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeltatimeTest : MonoBehaviour
{
    [SerializeField] TMP_Text progressText;
    float progress;

    [SerializeField] TMP_Text frameText;
    float frame;



    private void Update()
    {
        UpdateProgress();

        UpdateText();
    }

    void UpdateProgress()
    {
        progress += Time.deltaTime;

        frame += 1;
    }

    private void UpdateText()
    {
        progressText.SetText(progress.ToString());
        frameText.SetText(frame.ToString());
    }
}
