using UnityEngine;
using DG.Tweening;

public class OnCompleteExample : MonoBehaviour
{
    [SerializeField] private Transform target;

    public void PlayMove()
    {
        target.DOMoveX(3f, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                Debug.Log("이동 완료");
                gameObject.SetActive(false);
            });
    }
}