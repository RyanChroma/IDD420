using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Film : Item
{
    [SerializeField] private int amount;
    public override void onPickUP()
    {
        player.GetComponent<CameraAmmo>().IncreaseAmmo(amount);
    }
}
