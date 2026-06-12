using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GaugeAnimation : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private float duration = 0.25f;
    private float maxHp = 100f;
    private int count = 0;

    public void SetHp(float currentHp)
    {
        count++;
        currentHp *= count;
        
        float targetValue = currentHp / maxHp;

        hpSlider.DOKill();

        hpSlider.DOValue(targetValue, duration)
            .SetEase(Ease.OutQuad);
    }
}