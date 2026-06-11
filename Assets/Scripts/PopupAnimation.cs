using UnityEngine;
using DG.Tweening;

public class PopupAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform popup;
    [SerializeField] private CanvasGroup canvasGroup;

    private void OnEnable()
    {
        PlayOpenAnimation();
    }

    private void PlayOpenAnimation()
    {
        popup.DOKill();
        canvasGroup.DOKill();

        popup.localScale = Vector3.one * 0.8f;
        canvasGroup.alpha = 0f;

        canvasGroup.DOFade(1f, 0.15f);

        popup.DOScale(1f, 0.25f)
            .SetEase(Ease.OutBack);
    }
}