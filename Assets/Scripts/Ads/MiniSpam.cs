using System.Collections;
using UnityEngine;

public class MiniSpam : MonoBehaviour
{
    [SerializeField] PopUpBase popUpbase;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] BoxCollider2D col;

    [SerializeField] GameObject miniSpamChildPrefab;
    [SerializeField] float childSpawnInterval;
    [SerializeField] BasicButton button;

    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[index];


        if (index > 1)
        {
            col.size = new Vector2(4.95283f, 6.292453f);
        }

        StartCoroutine(SpawnChild());
        button.DisableButton();
    }

    IEnumerator SpawnChild()
    {
        yield return new WaitForSeconds(childSpawnInterval);

        for (int i = 0; i < 20; i++)
        {
            Vector3 pos = new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0f); 
            popUpbase.popUpManager.SpawnAd(miniSpamChildPrefab, pos, false);

            yield return new WaitForSeconds(childSpawnInterval);
        }

        button.EnableButton();
    }
}
