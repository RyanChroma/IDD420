using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
    [SerializeField] private float lifeAmount;
    public override void onPickUP()
    {
        player.GetComponent<CameraLife>().addLife(lifeAmount);
    }
}