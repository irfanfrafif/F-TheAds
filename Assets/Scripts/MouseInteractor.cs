using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractor : MonoBehaviour
{
    Camera cam;

    RaycastHit2D hit;

    GameObject draggedGameObject;
    bool isDragging;

    [SerializeField] bool isDragHold;
    [SerializeField] bool dragOnPivot;
    Vector2 offset;

    [SerializeField] PopUpManager popUpManager;

    private void Start()
    {
        cam = GameManager.Instance.cam;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
            return;
        }

        if (isDragging)
        {
            MoveDraggedObject();
        }
    }

    void HandleClick()
    {
        Vector2 mousePosition = GetMousePosition();
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (!hit)
        {
            Debug.Log("hit nothing");
            return;
        }

        if (!isDragHold && isDragging)
        {
            isDragging = false;
            return;
        }

        //if (hit.collider.TryGetComponent<ICli>)

        if (hit.collider.TryGetComponent<IDraggable>(out IDraggable draggable))
        {
            //draggable.DragOnClick(this);
            draggedGameObject = hit.collider.gameObject;
            if (!dragOnPivot)
            {
                offset = GetMousePosition() - (Vector2)draggedGameObject.transform.position;
            }
            else
            {
                offset = Vector2.zero;
            }
            isDragging = true;

            popUpManager.frontAds = draggedGameObject;
            popUpManager.RefreshZ();
            

            return;
        }

        return;
    }

    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void MoveDraggedObject()
    {
        //WTF is this abomination lol
        draggedGameObject.transform.position = new Vector3(GetMousePosition().x - offset.x, GetMousePosition().y - offset.y, draggedGameObject.transform.position.z);        

        if (isDragHold && Input.GetMouseButtonUp(0))
        {
            PutDownObject();
        }
    }

    void PutDownObject()
    {
        isDragging = false;
        draggedGameObject = null;
    }
}
