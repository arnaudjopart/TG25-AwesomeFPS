using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    [SerializeField] private float _highlightSize = 1.2f;
    [SerializeField] private float _highlightDuration = .2f;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        Tween.Scale(_rectTransform, Vector3.one*_highlightSize, _highlightDuration);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        Tween.Scale(_rectTransform, Vector3.one, _highlightDuration);
    }
}
