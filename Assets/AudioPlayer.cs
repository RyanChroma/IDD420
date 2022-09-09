using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioSource> sources = new List<AudioSource>();
    
    public void playAudio(int index)
    {
        sources[index].Play();
    }
}
