using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextHighlightEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text targetText;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = targetText.transform.localScale;
    }

    public void PlayHighlight()
    {
        targetText.transform.DOKill();

        targetText.transform.localScale = originalScale;

        targetText.transform
            .DOScale(originalScale * 1.2f, 0.12f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                targetText.transform
                    .DOScale(originalScale, 0.12f)
                    .SetEase(Ease.OutQuad);
            });
    }
}