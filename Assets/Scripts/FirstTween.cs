using UnityEngine;
using DG.Tweening;

public class FirstTween : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(3f, 1f)
            .SetEase(Ease.OutBack);
    }
}