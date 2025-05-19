using System;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField] Button _playButton;
    [SerializeField] private float _duration =.5f;
    [SerializeField] private Image _fadeOutImage;
    private Sequence _sequence;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.position = Vector3.left * _rectTransform.rect.width;
    }

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);

        Tween.UIAnchoredPosition(
            _rectTransform,
            Vector2.zero,
            _duration,
            Ease.OutBounce,
            startDelay: .5f);
    }

    private void OnPlayButtonClicked()
    {
        var sequence = Sequence.Create();
        sequence.Chain(
            Tween.UIAnchoredPosition(
                _rectTransform, 
                new Vector2(-700,0),
                _duration,
                Ease.Default));
        sequence.Chain(Tween.Alpha(_fadeOutImage, 1,2f)); 
        sequence.OnComplete(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        Debug.Log("Loading next level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
