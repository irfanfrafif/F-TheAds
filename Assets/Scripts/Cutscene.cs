using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Cutscene : MonoBehaviour
{
    [SerializeField] Image fade;
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Image image3;
    [SerializeField] Image image3_2;
    [SerializeField] Image image3_3;
    [SerializeField] Image image4;
    [SerializeField] Image image5;

    [SerializeField] GameObject a;
    [SerializeField] GameObject b;
    [SerializeField] GameObject c;

    Vector2 defaultVector = new Vector2(371, -185);

    [ContextMenu("Cutscene Test")]
    public void StartCutscene()
    {
        StartCoroutine(CutsceneSequence());
    }

    private void OnEnable()
    {
        StartCutscene();
    }

    void Image3_3shake()
    {
        image3_3.rectTransform.position = defaultVector;
    }

    IEnumerator CutsceneSequence()
    {
        fade.gameObject.SetActive(false);
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image3_2.gameObject.SetActive(false);
        image3_3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        image5.gameObject.SetActive(false);

        fade.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(8);

        fade.DOFade(0f, 0f);
        fade.DOFade(1f, 2f);

        yield return new WaitForSeconds(2f);

        image1.gameObject.SetActive(true);
        fade.DOFade(0f, 2f);

        yield return new WaitForSeconds(2f);

        image1.gameObject.SetActive(true);


        yield return new WaitForSeconds(2f);

        image2.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(8);

        yield return new WaitForSeconds(2f);

        image3.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(8);

        yield return new WaitForSeconds(0.75f);

        image3_2.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(8);

        yield return new WaitForSeconds(0.75f);

        image3_3.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(10);
        image3_3.rectTransform.DOShakeAnchorPos(4f, 100f, 100);

        yield return new WaitForSeconds(2f);

        image4.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(8);
        image4.rectTransform.DOShakeAnchorPos(0.3f, 50f, 400);

        yield return new WaitForSeconds(2f);

        image5.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(8);

        yield return new WaitForSeconds(2f);

        fade.DOFade(1f, 2f);
        a.SetActive(true);
        b.SetActive(true);
        c.SetActive(false);

        yield return new WaitForSeconds(2f);

        fade.DOFade(0f, 2f);
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image3_2.gameObject.SetActive(false);
        image3_3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        image5.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);


        gameObject.SetActive(false);
        AudioManager.instance.PlayAudio(8);

        //Total 21 seconds
    }
}
