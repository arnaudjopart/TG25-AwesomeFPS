using PrimeTween;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private RectTransform _healthBarContainer;
    [SerializeField] private RectTransform _healthBarContent;
    [SerializeField] private RectTransform _healthBarPreview;

    private float _maxWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemy.OnTakeDamageEvent+= UpdateDisplay;
        _maxWidth = _healthBarContainer.sizeDelta.x;
    }

    private void UpdateDisplay(int obj)
    {
        float percentage = obj/10f;
        var currentBarWidth = _healthBarContainer.sizeDelta.x*percentage;
        _healthBarContent.sizeDelta = new Vector2(currentBarWidth, _healthBarContent.sizeDelta.y);
        Tween.UISizeDelta(_healthBarPreview, new Vector2(currentBarWidth, _healthBarPreview.sizeDelta.y),.5f, startDelay:.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
