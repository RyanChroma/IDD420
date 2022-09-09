using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject winUI;

    private void OnEnable()
    {
        WinBox.onWin += CallUI;
    }
    private void OnDisable()
    {
        WinBox.onWin -= CallUI;
    }

    // Update is called once per frame
    public void CallUI()
    {
        winUI.SetActive(true);
    }
}
