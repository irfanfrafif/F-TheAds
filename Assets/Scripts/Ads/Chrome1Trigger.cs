using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrome1Trigger : MonoBehaviour
{
    [SerializeField] GameObject thisHammer;

    private void Start()
    {
        transform.localPosition = new Vector3(1f, -0.2f, transform.position.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject != thisHammer) return;
        if (collision.TryGetComponent<Hammer>(out Hammer hammer))
        {
            hammer.DoSomething();
            Debug.Log("YEET");
        }
    }
}
