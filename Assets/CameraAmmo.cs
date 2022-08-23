using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAmmo : MonoBehaviour
{
    public int flimCount = 3;
    public int maxFlim = 3;
    // Start is called before the first frame update
    public void DecreaseAmmo(int ammo)
    {
        flimCount -= ammo;
    }

    public void IncreaseAmmo(int ammo)
    {
        flimCount += ammo;
        flimCount = Mathf.Clamp(flimCount,0,maxFlim);
    }
}
