using UnityEngine;
using DG.Tweening;

public class RewardSequence : MonoBehaviour
{
    [SerializeField] private CanvasGroup rewardPanelGroup;
    [SerializeField] private Transform rewardIcon;
    [SerializeField] private CanvasGroup buttonGroup;

    private Sequence rewardSequence;

    public void PlayReward()
    {
        rewardSequence?.Kill();

        gameObject.SetActive(true);

        rewardPanelGroup.alpha = 0f;
        rewardIcon.localScale = Vector3.zero;
        buttonGroup.alpha = 0f;
        buttonGroup.interactable = false;
        buttonGroup.blocksRaycasts = false;

        rewardSequence = DOTween.Sequence();

        rewardSequence.Append(rewardPanelGroup.DOFade(1f, 0.2f));

        rewardSequence.Append(rewardIcon.DOScale(1.2f, 0.25f)
            .SetEase(Ease.OutBack));

        rewardSequence.Append(rewardIcon.DOScale(1f, 0.1f)
            .SetEase(Ease.OutQuad));

        rewardSequence.AppendInterval(0.3f);

        rewardSequence.Append(buttonGroup.DOFade(1f, 0.2f));

        rewardSequence.OnComplete(() =>
        {
            buttonGroup.interactable = true;
            buttonGroup.blocksRaycasts = true;
        });
    }
}