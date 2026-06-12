using UnityEngine;
using DG.Tweening;

public class DotweenMistakeExample : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = target.localScale;
    }

    public void PlayEffect()
    {
        target.DOKill();
        target.localScale = originalScale;

        target.DOScale(originalScale * 1.2f, 0.15f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                target.DOScale(originalScale, 0.15f);
            });
    }
}