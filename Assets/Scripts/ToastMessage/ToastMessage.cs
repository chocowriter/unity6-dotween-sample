using UnityEngine;
using TMPro;
using DG.Tweening;

public class ToastMessage : MonoBehaviour
{
    [SerializeField] private RectTransform toastPanel;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text messageText;

    [SerializeField] private float showDuration = 0.2f;
    [SerializeField] private float waitDuration = 1.2f;
    [SerializeField] private float hideDuration = 0.2f;

    private Vector2 originalPosition;

    private void Awake()
    {
        originalPosition = toastPanel.anchoredPosition;
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        gameObject.SetActive(true);

        toastPanel.DOKill();
        canvasGroup.DOKill();

        messageText.text = message;
        canvasGroup.alpha = 0f;
        toastPanel.anchoredPosition = originalPosition + new Vector2(0f, -30f);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(canvasGroup.DOFade(1f, showDuration));
        sequence.Join(toastPanel.DOAnchorPos(originalPosition, showDuration)
            .SetEase(Ease.OutQuad));

        sequence.AppendInterval(waitDuration);

        sequence.Append(canvasGroup.DOFade(0f, hideDuration));
        sequence.Join(toastPanel.DOAnchorPos(originalPosition + new Vector2(0f, -30f), hideDuration)
            .SetEase(Ease.InQuad));

        sequence.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}