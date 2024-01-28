using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpamChild : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] BoxCollider2D col;

    private void Start()
    {

        int index = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[index];
        

        if (index > 1)
        {
            col.size = new Vector2(4.95283f, 6.292453f);
        }
    }
}
