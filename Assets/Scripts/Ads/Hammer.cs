using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hammer : MonoBehaviour, IDraggable
{

    public UnityEvent onComplete;

    public PolygonCollider2D col;

    public bool dragged;

    void Start()
    {
        // StartCoroutine(DelayStartCol());
        transform.localPosition = new Vector3(3f, Random.Range(-1.2f, 0.6f), -0.1f);

        col.enabled = true;
    }

    public void OnClickDrag()
    {
        dragged = true;
    }

    public void DoSomething()
    {
        if (dragged) return;

        col.enabled = false;
        //Do extrathing

        onComplete.Invoke();
    }

    public void OnClickRelease()
    {
        dragged = false;
    }

    IEnumerator DelayStartCol()
    {
        yield return new WaitForSeconds(0.2f);

        transform.localPosition = new Vector3(3f, Random.Range(-1.2f, 0.6f), -0.1f);

        col.enabled = true;
    }
}
