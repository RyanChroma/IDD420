using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SceneChangeButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            SceneLoader.loadScene(sceneName);
        }
    }
}
