using UnityEngine;
using DG.Tweening;

public class AppendJoinExample : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CanvasGroup canvasGroup;

    public void PlayAppendExample()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(target.DOScale(1.2f, 0.2f));
        sequence.Append(target.DOMoveY(target.position.y + 1f, 0.3f));
        sequence.Append(canvasGroup.DOFade(0f, 0.2f));
    }
}