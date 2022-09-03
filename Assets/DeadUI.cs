using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadUI : MonoBehaviour
{
    [SerializeField] Transform deadUI;

    private void Start()
    {
        DeathCall.onPlayerDeath += enableUI;
    }

    private void OnDestroy()
    {
        DeathCall.onPlayerDeath -= enableUI;
    }

    public void disableUI()
    {
        deadUI.gameObject.SetActive(false);
    }

    public void enableUI()
    {
        deadUI.gameObject.SetActive(true);
    }

}
