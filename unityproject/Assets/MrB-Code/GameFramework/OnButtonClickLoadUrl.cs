﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// When a button is clicked then load the specificed Url
/// 
/// This automatically hooks up the button onClick listener
/// </summary>
[RequireComponent(typeof(Button))]
public class OnButtonClickLoadUrl : MonoBehaviour
{
    public string AndroidUrl;
    public string DesktopUrl;
    public string IOsUrl;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
#if UNITY_ANDROID
        Application.OpenURL(AndroidUrl);
#elif UNITY_IPHONE
            Application.OpenURL(iOSUrl);
#else
            Application.OpenURL(DesktopUrl);
#endif
    }
}
