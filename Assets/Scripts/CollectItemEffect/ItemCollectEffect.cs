using System;
using UnityEngine;
using DG.Tweening;

public class ItemCollectEffect : MonoBehaviour
{
    [SerializeField] private Transform itemIcon;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Start()
    {
        PlayCollectEffect();
    }

    public void PlayCollectEffect()
    {
        itemIcon.DOKill();
        canvasGroup.DOKill();

        itemIcon.DOScale(1.2f, 0.15f)
            .SetEase(Ease.OutBack);

        itemIcon.DOMove(targetPoint.position, 0.5f)
            .SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                canvasGroup.DOFade(0f, 0.2f)
                    .OnComplete(() =>
                    {
                        gameObject.SetActive(false);
                    });
            });
    }
}