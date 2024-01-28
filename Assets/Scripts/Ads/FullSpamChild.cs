using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSpamChild : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    private void Awake()
    {
        transform.position = new Vector3(0f, 0f, transform.position.z);
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
