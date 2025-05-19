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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.anchoredPosition = new Vector2(-700, 0);
    }

    private void Start()
    {
        Tween.UIAnchoredPosition(
            _rectTransform, 
            Vector2.zero, 
            _duration,
            Ease.OutBounce,
            1,CycleMode.Restart,.5f);
        _playButton.onClick.AddListener(OnPlayButtonClicked);
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
        sequence.Chain(Tween.Alpha(_fadeOutImage, 1,1f)); 
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
