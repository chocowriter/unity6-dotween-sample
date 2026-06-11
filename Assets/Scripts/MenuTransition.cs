using UnityEngine;
using DG.Tweening;

public class MenuTransition : MonoBehaviour
{
    [SerializeField] private CanvasGroup currentMenu;
    [SerializeField] private CanvasGroup nextMenu;

    public void ChangeMenu()
    {
        currentMenu.DOKill();
        nextMenu.DOKill();

        nextMenu.gameObject.SetActive(true);
        nextMenu.alpha = 0f;

        currentMenu.DOFade(0f, 0.2f)
            .OnComplete(() =>
            {
                currentMenu.gameObject.SetActive(false);

                nextMenu.DOFade(1f, 0.2f);
            });
    }
}