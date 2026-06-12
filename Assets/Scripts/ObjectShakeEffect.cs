using UnityEngine;
using DG.Tweening;

public class ObjectShakeEffect : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = target.localPosition;
    }

    public void PlayShake()
    {
        target.DOKill();

        target.localPosition = originalPosition;

        target.DOShakePosition(
            duration: 0.2f,
            strength: 0.2f,
            vibrato: 15,
            randomness: 90f
        ).OnComplete(() =>
        {
            target.localPosition = originalPosition;
        });
    }
}