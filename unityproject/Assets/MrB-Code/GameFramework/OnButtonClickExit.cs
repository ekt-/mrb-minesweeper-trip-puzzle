﻿using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Quit the game when clicked
/// 
/// This automatically hooks up the button onClick listener
/// </summary>
[RequireComponent(typeof(Button))]
public class OnButtonClickExit : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Application.Quit();

    }
}
