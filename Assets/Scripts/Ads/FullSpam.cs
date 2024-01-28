using System.Collections;
using UnityEngine;

public class FullSpam : MonoBehaviour
{
    [SerializeField] PopUpBase popUpbase;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    [SerializeField] GameObject fullSpamChildPrefab;
    [SerializeField] float childSpawnInterval;
    [SerializeField] BasicButton button;

    private void Awake()
    {
        transform.position = new Vector3(0f, 0f, transform.position.z);
    }

    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        StartCoroutine(SpawnChild());
        button.DisableButton();
    }

    IEnumerator SpawnChild()
    {
        yield return new WaitForSeconds(childSpawnInterval);

        for (int i = 0; i < 20; i++)
        {
            popUpbase.popUpManager.SpawnAd(fullSpamChildPrefab, transform.position, false);

            yield return new WaitForSeconds(childSpawnInterval);
        }

        button.EnableButton();
    }
}
