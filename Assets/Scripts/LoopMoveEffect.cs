using UnityEngine;
using DG.Tweening;

public class LoopMoveEffect : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = target.localPosition;
    }

    private void OnEnable()
    {
        PlayLoopMove();
    }

    private void OnDisable()
    {
        target.DOKill();
    }

    private void PlayLoopMove()
    {
        target.localPosition = originalPosition;

        target.DOLocalMoveY(originalPosition.y + 0.3f, 0.8f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}