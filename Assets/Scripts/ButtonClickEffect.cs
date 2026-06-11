using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonClickEffect : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Transform target;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = target.localScale;

        button.onClick.AddListener(PlayClickEffect);
    }

    private void PlayClickEffect()
    {
        target.DOKill();

        target.localScale = originalScale;

        target.DOScale(originalScale * 0.9f, 0.08f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                target.DOScale(originalScale, 0.12f)
                    .SetEase(Ease.OutBack);
            });
    }
}