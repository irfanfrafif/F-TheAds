using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBatmanSpawner : MonoBehaviour
{
    [SerializeField] BasicButton[] buttons;
    [SerializeField] Sprite realSprite;

    private void Start()
    {
        int realIndex = Random.Range(0, buttons.Length);

        buttons[realIndex].ChangeSprite(realSprite);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == realIndex) continue;

            buttons[i].DisableButton();
        }
    }
}
