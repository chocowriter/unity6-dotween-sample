using UnityEngine;
using DG.Tweening;

public class TweenDisableExample : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = target.localScale;
    }

    private void OnEnable()
    {
        target.localScale = originalScale;

        target.DOScale(originalScale * 1.1f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    private void OnDisable()
    {
        target.DOKill();
        target.localScale = originalScale;
    }
}