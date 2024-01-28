using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpingBatman : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float gravity = 1f;
    [SerializeField] float jumpSpeed = 2f;
    float originalY;
    [SerializeField] float heightToFinish;

    public UnityEvent onComplete;

    private void Awake()
    {
        
    }

    private void Start()
    {
        originalY = transform.localPosition.y;
    }

    public void Jump()
    {
        rb.velocity = new Vector2(0f, jumpSpeed);
    }

    private void Update()
    {
        if (rb.velocity.y > -20)
        {
            rb.velocity += new Vector2(0f, -gravity * Time.deltaTime);
        }       
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Max(originalY, transform.localPosition.y), transform.localPosition.z);

        if(transform.localPosition.y > originalY + heightToFinish)
        {
            Finish();
        }
    }

    void Finish()
    {
        onComplete.Invoke();
    }
}
