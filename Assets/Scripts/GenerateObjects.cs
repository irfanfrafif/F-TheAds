using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    public List<GameObject> listPoinSpawn = new List<GameObject>();
    public GameObject realSpawn, dummySpawn;
    private int totalSpawn, realPick;
    private bool isSpawn = false;

    [SerializeField] GameObject realDeal;

    private void Start() {
        totalSpawn = listPoinSpawn.Count;
        realPick = UnityEngine.Random.Range(0, --totalSpawn);
        Debug.Log("Kunci di " + realPick);

    }

    private void Update() {
        if (!isSpawn) spawnPrefab();
    }

    private void spawnPrefab() {
        for (int i = 0; i < listPoinSpawn.Count; i++) {
            Transform transformChildList = listPoinSpawn[i].GetComponent<Transform>();
            Vector3 spawnPos = new Vector3(transformChildList.gameObject.transform.position.x, transformChildList.gameObject.transform.position.y, transformChildList.gameObject.transform.position.z);
            if (i != realPick) {
                Instantiate(dummySpawn, spawnPos, Quaternion.identity, transform);
            } else {
                //Instantiate(realSpawn, spawnPos, Quaternion.identity);
                realDeal.transform.position = spawnPos;
            }
        }
        isSpawn = true;
    }
}
