using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetting : MonoBehaviour
{
    [SerializeField] private string startUpMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance?.PlayBGM(startUpMusic);
    }


}
