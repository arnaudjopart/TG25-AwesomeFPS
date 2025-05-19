using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    [SerializeField] private float _highlightSize = 1.2f;
    [SerializeField] private float _highlightDuration = .2f;
    [SerializeField] private Ease _easeIn = Ease.InCubic;

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
            Vector3.one * _highlightSize,
            _highlightDuration,
            _easeIn);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tween.Scale(
            _rectTransform, 
            Vector3.one, 
            _highlightDuration);
    }
}
