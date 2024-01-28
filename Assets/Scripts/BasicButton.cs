using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BasicButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    SpriteRenderer spriteRenderer;
    [Space(2)]
    public bool interactable = true;

    [Space(2)]
    [Header("Sprite")]
    [SerializeField] Sprite idle;
    [SerializeField] Sprite hover;
    [SerializeField] Sprite clicked;
    [SerializeField] Sprite disabled;

    [Space(5)]
    [Header("Navigation")]
    [SerializeField] bool disableOnClick;
    [Space(2)]
    public UnityEvent onClick;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idle;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!interactable) return;       
        onClick.Invoke();
        if(disableOnClick)
        {
            spriteRenderer.sprite = disabled;
            DisableButton();
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable) return;
        spriteRenderer.sprite = hover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable) return;
        spriteRenderer.sprite = idle;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!interactable) return;
        spriteRenderer.sprite = clicked;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!interactable) return;
        spriteRenderer.sprite = idle;
    }

    public void DisableButton()
    {
        interactable = false;
        spriteRenderer.sprite = disabled;
    }

    public void EnableButton()
    {
        interactable = true;
        spriteRenderer.sprite = idle;
    }

    public void ChangeSprite(Sprite sprite) {
        idle = sprite;
        hover = sprite;
        clicked = sprite;
        disabled = sprite;
        spriteRenderer.sprite = sprite;
    }
}
