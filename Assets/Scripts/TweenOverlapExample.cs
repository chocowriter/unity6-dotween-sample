using UnityEngine;
using DG.Tweening;

public class TweenOverlapExample : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = target.localScale;
    }

    public void PlayScaleEffect()
    {
        target.DOKill();

        target.localScale = originalScale;

        target.DOScale(originalScale * 1.2f, 0.15f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                target.DOScale(originalScale, 0.15f)
                    .SetEase(Ease.OutQuad);
            });
    }
}