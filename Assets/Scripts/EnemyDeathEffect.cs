using UnityEngine;
using DG.Tweening;

public class EnemyDeathEffect : MonoBehaviour
{
    [SerializeField] private Transform enemyBody;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Color originalColor;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    public void PlayDeathEffect()
    {
        enemyBody.DOKill();
        spriteRenderer.DOKill();

        enemyBody.localScale = Vector3.one;
        spriteRenderer.color = originalColor;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(enemyBody.DOScale(1.2f, 0.1f)
            .SetEase(Ease.OutBack));

        sequence.Join(spriteRenderer.DOColor(Color.white, 0.1f));

        sequence.Append(enemyBody.DOScale(0f, 0.25f)
            .SetEase(Ease.InBack));

        sequence.Join(spriteRenderer.DOFade(0f, 0.25f));

        sequence.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}