using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HurtUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup hurtOverlay;
    private Health health;
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        health.onHealthChange += overlayFunction;
    }

    private void OnDisable()
    {
        health.onHealthChange -= overlayFunction;
    }

    public void overlayFunction()
    {
        StartCoroutine(callOverlay());
    }

    IEnumerator callOverlay()
    {
        Tween hurtTween = hurtOverlay.DOFade(0.4f,0.2f).SetAutoKill(false).OnComplete(()=> { hurtOverlay.DORewind(); });
        yield return hurtTween.WaitForRewind();

        hurtTween.Kill();
    }
}
