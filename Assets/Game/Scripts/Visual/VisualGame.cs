using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class VisualGame : MonoBehaviour
{
    [SerializeField] private SearchText _searchText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Image _loadingPanel;

    private CanvasGroup _searchTextCanvasGroup;
    public CanvasGroup SearchTextCanvasGroup => _searchTextCanvasGroup;

    private void Awake()
    {
        _searchTextCanvasGroup = _searchText.GetComponent<CanvasGroup>();
    }

    public void RestartButton(bool active)
    {
        _restartButton.gameObject.SetActive(active);
    }

    public void UpdateSearchText(string text)
    {
        _searchText.UpdateText(text);
    }

    public void FadeIn(float value, float duration = 1f)
    {
        Fade(value, duration);
    }

    public void FadeOut(float duration = 1f)
    {
        Fade(0f, duration);
    }

    private void Fade(float value, float duration)
    {
        _loadingPanel.DOFade(value, duration);
    }
}
