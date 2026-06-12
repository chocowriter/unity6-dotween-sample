using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CombatFeedback : MonoBehaviour
{
    [SerializeField] private Transform attacker;
    [SerializeField] private Transform target;
    [SerializeField] private Slider hpBar;

    private Vector3 attackerStartPos;

    private void Awake()
    {
        attackerStartPos = attacker.position;
    }

    public void PlayAttackFeedback(float newHpValue)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(attacker.DOMoveX(attacker.position.x + 0.5f, 0.1f));
        sequence.Append(target.DOShakePosition(0.2f, 0.2f, 10, 90));
        sequence.Join(hpBar.DOValue(newHpValue, 0.25f));
        sequence.Append(attacker.DOMove(attackerStartPos, 0.15f));
    }
}