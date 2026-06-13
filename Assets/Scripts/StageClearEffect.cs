using UnityEngine;
using TMPro;
using DG.Tweening;

public class StageClearEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup dimGroup;
    [SerializeField] private TMP_Text clearText;
    [SerializeField] private CanvasGroup rewardGroup;
    [SerializeField] private CanvasGroup nextButtonGroup;

    private Sequence clearSequence;
    private Vector3 originalTextScale;

    private void Awake()
    {
        originalTextScale = clearText.transform.localScale;
    }

    public void PlayStageClear()
    {
        clearSequence?.Kill();

        gameObject.SetActive(true);

        dimGroup.alpha = 0f;
        rewardGroup.alpha = 0f;
        nextButtonGroup.alpha = 0f;
        nextButtonGroup.interactable = false;
        nextButtonGroup.blocksRaycasts = false;

        clearText.transform.localScale = Vector3.zero;

        clearSequence = DOTween.Sequence();

        clearSequence.Append(dimGroup.DOFade(1f, 0.3f));

        clearSequence.Append(clearText.transform
            .DOScale(originalTextScale * 1.2f, 0.35f)
            .SetEase(Ease.OutBack));

        clearSequence.Append(clearText.transform
            .DOScale(originalTextScale, 0.15f)
            .SetEase(Ease.OutQuad));

        clearSequence.AppendInterval(0.3f);

        clearSequence.Append(rewardGroup.DOFade(1f, 0.25f));

        clearSequence.Append(nextButtonGroup.DOFade(1f, 0.2f));

        clearSequence.OnComplete(() =>
        {
            nextButtonGroup.interactable = true;
            nextButtonGroup.blocksRaycasts = true;
        });
    }

    private void OnDisable()
    {
        clearSequence?.Kill();
    }
}