using UnityEngine;
using DG.Tweening;

public class HitReaction : MonoBehaviour
{
    [SerializeField] private Transform characterBody;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Color originalColor;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    public void PlayHitReaction()
    {
        characterBody.DOKill();
        spriteRenderer.DOKill();

        characterBody.localPosition = Vector3.zero;
        spriteRenderer.color = originalColor;

        characterBody.DOShakePosition(0.15f, 0.15f, 10, 90f);

        spriteRenderer.DOColor(Color.red, 0.08f)
            .OnComplete(() =>
            {
                spriteRenderer.DOColor(originalColor, 0.08f);
            });
    }
}