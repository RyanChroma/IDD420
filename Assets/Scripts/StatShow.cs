using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCount;
    [SerializeField] private TextMeshProUGUI life;
    [SerializeField] private CameraLife cameraLife;
    [SerializeField] private CameraAmmo cameraAmmo;

    private void Update()
    {
        life.text = "Battery Life: " + cameraLife.currentLife.ToString("0") + "/100";
        ammoCount.text = "Film: " + cameraAmmo.flimCount.ToString();
    }
}
