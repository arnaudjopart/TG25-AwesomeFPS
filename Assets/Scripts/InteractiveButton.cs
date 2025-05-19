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
        Tween.Scale(
            _rectTransform, 
            new Vector3(_highlightSize,1,1), 
            _highlightDuration,
            Ease.InBounce);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tween.Scale(
            _rectTransform, 
            Vector3.one, 
            _highlightDuration);
    }
}
