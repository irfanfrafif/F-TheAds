using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    float saturation;

    private void Update()
    {
        saturation += Time.deltaTime;

        float a = Mathf.Clamp(saturation / 200f, 0, 0.5f);

        spriteRenderer.color = Color.HSVToRGB(AbsSin(Time.time * 0.25f), a, 0.9f);
    }

    float AbsSin(float input)
    {
        return Mathf.Abs(Mathf.Sin(Time.time));
    }
}
