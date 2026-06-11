using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GaugeAnimation : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private float duration = 0.25f;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        float current = hpSlider.value;
        current += 1f;
        SetHp(current, 10f);
    }


    public void SetHp(float currentHp, float maxHp)
    {
        float targetValue = currentHp / maxHp;

        hpSlider.DOKill();

        hpSlider.DOValue(targetValue, duration)
            .SetEase(Ease.OutQuad);
    }
}