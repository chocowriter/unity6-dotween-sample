using UnityEngine;
using DG.Tweening;

public class SequenceExample : MonoBehaviour
{
    [SerializeField] private Transform target;

    public void PlayEffect()
    {
        target.DOKill();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(target.DOScale(1.2f, 0.2f)
            .SetEase(Ease.OutBack));

        sequence.Append(target.DOMoveY(target.position.y + 1f, 0.3f)
            .SetEase(Ease.OutQuad));

        sequence.Append(target.DOScale(0f, 0.2f)
            .SetEase(Ease.InBack));
    }
}