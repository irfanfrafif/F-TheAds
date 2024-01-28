using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeAdsSpawn : MonoBehaviour
{
    public List<GameObject> listPoinSpawn = new List<GameObject>();
    private int totalSpawn, realPick;
    private bool isSpawn = false;
    private int tempRealDeal;

    [SerializeField] GameObject zonkDeal;
    [SerializeField] GameObject[] realDeal;

    [SerializeField] PopUpBase popUpBase;

    private void Start() {
        totalSpawn = listPoinSpawn.Count;
        realPick = UnityEngine.Random.Range(0, totalSpawn);
        tempRealDeal = 0;
        Debug.Log("Kunci di " + realPick);

    }

    private void Update() {
        if (!isSpawn) spawnPrefab();
    }

    private void spawnPrefab() {
        for (int i = 0; i < totalSpawn; i++) {
            Debug.Log(tempRealDeal);
            Transform transformChildList = listPoinSpawn[i].GetComponent<Transform>();
            Vector3 spawnPos = new Vector3(transformChildList.gameObject.transform.position.x, transformChildList.gameObject.transform.position.y, transformChildList.gameObject.transform.position.z);
            if (i == realPick) {
                zonkDeal.transform.position = spawnPos;
            } else {
                realDeal[tempRealDeal].transform.position = spawnPos;
                tempRealDeal++;
            }
        }
        isSpawn = true;
    }

    public void SpawnAnother()
    {
        popUpBase.popUpManager.SpawnRandomAd();
    }
}
