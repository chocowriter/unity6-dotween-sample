using UnityEngine;
using DG.Tweening;

public class PopupOpenSequence : MonoBehaviour
{
    [SerializeField] private CanvasGroup dimGroup;
    [SerializeField] private CanvasGroup popupGroup;
    [SerializeField] private RectTransform popupPanel;

    private Sequence openSequence;

    public void Open()
    {
        openSequence?.Kill();

        gameObject.SetActive(true);

        dimGroup.alpha = 0f;
        popupGroup.alpha = 0f;
        popupPanel.localScale = Vector3.one * 0.8f;

        openSequence = DOTween.Sequence();

        openSequence.Append(dimGroup.DOFade(1f, 0.15f));

        openSequence.Join(popupGroup.DOFade(1f, 0.2f));

        openSequence.Join(
            popupPanel.DOScale(1f, 0.25f)
                .SetEase(Ease.OutBack)
        );
    }
}