using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

public class PopUpManager : MonoBehaviour
{
    [Header("Ads")]
    [SerializeField] GameObject[] lvl1AdsPrefabs;
    [SerializeField] GameObject[] lvl2AdsPrefabs;
    public List<GameObject> activeAds;
    public GameObject frontAds;

    [Header("Gameplay")]
    [SerializeField] float spawnInterval;
    [SerializeField] int currentLevel = 1;
    [SerializeField] int adCount;
    public bool isGameRunning;
    public int setRage = 2;
    public int setOver = 4;

    [Header("Misc")]
    [SerializeField] TMP_Text ram;
    [SerializeField] GameObject gameOverText;
    bool gameOver;
    bool rageMode;
    [SerializeField] Camera cam;

    public UnityEvent onDeath;


    int[] level1Chance = new int[5] { 1, 1, 1, 1, 1 };
    int[] level2Chance = new int[5] { 1, 1, 1, 1, 1 };

    private void Start()
    {
        
    }

    public void StartGame()
    {
        StopCoroutine(SpawnerLogic());
        StartCoroutine(SpawnerLogic());
    }

    public void SpawnRandomAd()
    {
        int whichAdLevel;
        switch (currentLevel)
        {
            case 1:
                whichAdLevel = level1Chance[Random.Range(0, level1Chance.Length)];
                break;
            case 2:
                whichAdLevel = level2Chance[Random.Range(0, level2Chance.Length)];
                break;
            default:
                whichAdLevel = 1;
                break;
        }

        int index;
        GameObject adPrefab;
        switch (whichAdLevel)
        {
            case 1:
                index = Random.Range(0, lvl1AdsPrefabs.Length);
                adPrefab = lvl1AdsPrefabs[index];
                break;
            case 2:
                index = Random.Range(0, lvl2AdsPrefabs.Length);
                adPrefab = lvl2AdsPrefabs[index];
                break;
            default:
                index = 0;
                adPrefab = lvl1AdsPrefabs[index];
                break;
        }

        SpawnAd(adPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f), true);
    }

    public void SpawnAd(GameObject prefab, Vector3 position, bool isCounted)
    {
        var newAds = Instantiate(prefab, new Vector3(position.x, position.y, 0f), Quaternion.identity);
        AudioManager.instance.PlayAudio(1);

        newAds.GetComponent<PopUpBase>().popUpManager = this;
        newAds.GetComponent<PopUpBase>().isCounted = isCounted;

        frontAds = newAds;

        activeAds.Add(newAds);

        if (isCounted) adCount++;

        RefreshZ();
    }

    public void RefreshZ()
    {
        foreach (var ad in activeAds)
        {
            ad.transform.position = new Vector3(ad.transform.position.x, ad.transform.position.y, ad.transform.position.z + 1);
        }
        frontAds.transform.position = new Vector3(frontAds.transform.position.x, frontAds.transform.position.y, 0);
    }

    IEnumerator SpawnerLogic()
    {
        isGameRunning = true;

        yield return new WaitForSeconds(5f);

        while (isGameRunning)
        {
            SpawnRandomAd();

            yield return new WaitForSeconds(spawnInterval);          
        }
    }

    public void CloseAd(GameObject closedAd)
    {
        AudioManager.instance.PlayAudio(0);
        activeAds.Remove(closedAd);
        if (closedAd.GetComponent<PopUpBase>().isCounted) adCount--;
        Destroy(closedAd);
    }

    public void CloseAllAd()
    {
        AudioManager.instance.PlayAudio(0);
        foreach (var closedAd in activeAds)
        {
            Destroy(closedAd);
        }
        activeAds.Clear();
        adCount = 0;
    }


    private void Update()
    {
        ram.SetText("RAM USAGE: " + adCount + "GB");

        if(adCount >= setRage && !rageMode)
        {
            rageMode = true;
            //cam.DOShakePosition(999f, 1f, 3);
        }

        if(adCount >= setOver && !gameOver)
        {
            gameOver = true;
            AudioManager.instance.PlayAudio(2);
            isGameRunning = false;
            GameManager.Instance.isOver = true;
            onDeath.Invoke();
            //Time.timeScale = 0f;
            //gameOverText.SetActive(true);
        }
    }

    public void StopSpawn()
    {
        isGameRunning = false;
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
    }

    public void SetSpawnInterval(int interval)
    {
        spawnInterval = interval;
    }

    public void SetOver(int over)
    {
        setOver = over;
    }
}
