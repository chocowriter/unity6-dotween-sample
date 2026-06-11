using System;
using UnityEngine;
using UnityEngine.UI;

public class OpenToast : MonoBehaviour
{
    public Button button;
    public ToastMessage toast;

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        toast.Show("HI");
    }

}
