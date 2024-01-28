using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckBox : MonoBehaviour
{
    [SerializeField] PopUpBase popUpbase;

    [SerializeField] BasicButton checkBox;
    [SerializeField] float childSpawnInterval;

    bool spawning = true;

    public UnityEvent onComplete;

    private void Start()
    {
        StartCoroutine(SpawnLogic());
    }

    public void ButtonClicked()
    {
        StartCoroutine(OnButtonClicked());
    }

    IEnumerator SpawnLogic()
    {
        yield return new WaitForSeconds(childSpawnInterval);

        while (spawning)
        {
            popUpbase.popUpManager.SpawnRandomAd();

            yield return new WaitForSeconds(childSpawnInterval);
        }
    }

    IEnumerator OnButtonClicked()
    {
        spawning = false;

        yield return new WaitForSeconds(5f);

        onComplete.Invoke();
    }
}
