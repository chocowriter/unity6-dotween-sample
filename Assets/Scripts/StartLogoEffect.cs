using UnityEngine;
using DG.Tweening;

public class StartLogoEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup logoGroup;
    [SerializeField] private RectTransform logoTransform;

    [SerializeField] private float fadeInDuration = 0.5f;
    [SerializeField] private float scaleDuration = 0.5f;
    [SerializeField] private float waitDuration = 1.0f;
    [SerializeField] private float fadeOutDuration = 0.5f;

    private Sequence logoSequence;

    private void Start()
    {
        PlayLogoEffect();
    }

    private void PlayLogoEffect()
    {
        logoSequence?.Kill();

        logoGroup.alpha = 0f;
        logoTransform.localScale = Vector3.one * 0.8f;

        logoSequence = DOTween.Sequence();

        logoSequence.Append(logoGroup.DOFade(1f, fadeInDuration));

        logoSequence.Join(
            logoTransform.DOScale(1f, scaleDuration)
                .SetEase(Ease.OutBack)
        );

        logoSequence.AppendInterval(waitDuration);

        logoSequence.Append(logoGroup.DOFade(0f, fadeOutDuration));

        logoSequence.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void OnDisable()
    {
        logoSequence?.Kill();
    }
}