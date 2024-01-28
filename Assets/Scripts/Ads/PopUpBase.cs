using UnityEngine;
using DG.Tweening;

public class PopUpBase : MonoBehaviour, IDraggable
{
    public PopUpManager popUpManager;
    public bool isCounted;

    [SerializeField] bool disableZoomin;

    public void Awake()
    {
        Vector3 originalScale = transform.localScale;
        if(!disableZoomin)
        {
            transform.localScale = new Vector3(0f, 0f, 0f);
            transform.DOScale(originalScale, 0.5f);
        }
        
    }

    //Unused Interface Implementation
    public void OnClickDrag()
    {
        return;
    }

    [ContextMenu("Delete Ad")]
    public void CloseAd()
    {
        popUpManager.CloseAd(gameObject);
    }

    public void OnClickRelease()
    {
        throw new System.NotImplementedException();
    }
}
