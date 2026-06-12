using UnityEngine;
using DG.Tweening;

public class KillCompleteExample : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Tween moveTween;

    public void PlayMove()
    {
        moveTween?.Kill();

        moveTween = target.DOMoveX(3f, 1f)
            .SetEase(Ease.OutQuad);
    }

    public void StopMove()
    {
        moveTween?.Kill();
    }

    public void FinishMoveImmediately()
    {
        moveTween?.Complete();
    }
}